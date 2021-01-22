    public class Uart : SerialPort
    {
        private int _receiveTimeout;
        public int ReceiveTimeout { get => _receiveTimeout; set => _receiveTimeout = value; }
        static private string ComPortName = "";
        /// <summary>
        /// It builds PortName using ComPortNum parameter and opens SerialPort.
        /// </summary>
        /// <param name="ComPortNum"></param>
        public Uart(int ComPortNum) : base()
        {
            base.BaudRate = 115200; // default value           
            _receiveTimeout = 2000;
            ComPortName = "COM" + ComPortNum;
            try
            {
                base.PortName = ComPortName;
                base.Open();
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: Port {0} is in use", ComPortName);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uart exception: " + ex);
            }
        } //Uart()
	
        /// <summary>
        /// Private property returning positive only Environment.TickCount
        /// </summary>
        private int _tickCount { get => Environment.TickCount & Int32.MaxValue; }
        /// <summary>
        /// It uses SerialPort.BaseStream rather SerialPort functionality .
        ///	It Receives up to maxLen number bytes of data, 
        /// Or throws TimeoutException if no any data arrived during ReceiveTimeout. 
        /// It works likes socket-recv routine (explanation in body).
        /// Returns:
        ///    totalReceived - bytes, 
        ///    TimeoutException,
        ///    -1 in non-ComPortNum Exception  
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="maxLen"></param>
        /// <returns></returns>
        public int Recv(byte[] buffer, int maxLen)
        {
            /// The routine works in "pseudo-blocking" mode. It cycles up to first 
			/// data received using BaseStream.ReadTimeout = TimeOutSpan (2 ms).
            /// If no any message received during ReceiveTimeout property, 
            /// the routine throws TimeoutException 
            /// In other hand, if any data has received, first no-data cycle
			///	causes to exit from routine.
            int TimeOutSpan = 2;
            // counts delay in TimeOutSpan-s after end of data to break receive
            int EndOfDataCnt;
            // pseudo-blocking timeout counter
            int TimeOutCnt = _tickCount + _receiveTimeout; 
            //number of currently received data bytes
            int justReceived = 0;
            //number of total received data bytes
            int totalReceived = 0;
            BaseStream.ReadTimeout = TimeOutSpan;
            //causes (2+1)*TimeOutSpan delay after end of data in UART stream
            EndOfDataCnt = 2;
            while (_tickCount < TimeOutCnt && EndOfDataCnt > 0)
            {
                try
                {
                    justReceived = 0; 
                    justReceived = base.BaseStream.Read(buffer, totalReceived, maxLen - totalReceived);
                    totalReceived += justReceived;
                    if (totalReceived >= maxLen)
                        break;
                }
                catch (TimeoutException)
                {
                    if (totalReceived > 0) 
                    {
                        EndOfDataCnt--;
                    }
                }
                catch (Exception ex)
                {                   
                    totalReceived = -1;
                    base.Close();
                    Console.WriteLine("Recv exception: " + ex);
                    break;
                }
            } //while
            if (totalReceived == 0)
            {              
                throw new TimeoutException();
            }
            else
            {               
                return totalReceived;
            }
        } // Recv()            
    } // Uart
 
