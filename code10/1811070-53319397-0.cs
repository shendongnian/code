    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net;
    using System.Net.Sockets;
    using System.Data;
    using System.Data.SqlClient;
    using System.Timers;
    using System.Threading;
    namespace TCP_Server
    {
        public class StateObject
        {
            public long connectionNumber = -1;
            public Socket workSocket { get; set; }
            public byte[] buffer { get; set; }
            public int fifoCount { get; set; }
        }
        public enum PROCESS_STATE
        {
            ACCEPT,
            READ,
            PROCESS,
            UNPACK
        }
        public enum UNPACK_STATUS
        {
            ERROR,
            NOT_ENOUGH_BYTES,
            BAD_CRC,
            GOOD_MESSAGE,
            DEFAULT
        }
        public enum PROTOCOL_NUMBER
        {
            LOGIN_MESSAGE,
            NONE
        }
        class Program
        {
            const string IP = "127.0.0.1";
            const int PORT = 8841;
            const Boolean test = true;
            static void Main(string[] args)
            {
                Server server = new Server(IP, PORT, test);
                Console.WriteLine("Connection Ended");
            }
        }
      
        public class Server
        {
            const int BUFFER_SIZE = 1024;
            const string CONNECT_STRING = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyDataTable;Integrated Security=SSPI;";
            const string LOGIN_INSERT_COMMMAND_TEXT = "use MyTable INSERT INTO Login (TerminalID,Date) VALUES(@TerminalID,@Date)";
            const string LOCATION_INSERT_COMMMAND_TEXT = "INSERT INTO MyTable (CurrTime, Message)" +
                "VALUES (@CurrTime, @Message)";
            static SqlConnection conn = null;
            static SqlCommand cmdLogin = null;
            static SqlCommand cmdLocation = null;
            static long connectionNumber = 0;
            //mapping of connection number to StateObject
            static Dictionary<long, KeyValuePair<List<byte>, StateObject>> connectionDict = new Dictionary<long, KeyValuePair<List<byte>, StateObject>>();
            //fifo contains list of connections number wait with receive data
            public static List<long> fifo = new List<long>();
            public static AutoResetEvent allDone = new AutoResetEvent(false);
            public static AutoResetEvent acceptDone = new AutoResetEvent(false);
            public enum DATABASE_MESSAGE_TYPE
            {
                LOGIN,
                LOCATION
            }
            public class WriteDBMessage
            {
                public DATABASE_MESSAGE_TYPE message { get; set; }
            }
            public class WriteDBMessageLogin : WriteDBMessage
            {
                public DateTime date { get; set; }
                public string message { get; set; }
            }
            public class WriteDBMessageLocation : WriteDBMessage
            {
                public DateTime currTime { get; set; }
                public byte[] message { get; set; }
            }
            public static class WriteDBAsync
            {
                public enum Mode
                {
                    READ,
                    WRITE
                }
                public static List<WriteDBMessage> fifo = new List<WriteDBMessage>();
                public static System.Timers.Timer timer = null;
                public static void WriteDatabase()
                {
                    timer = new System.Timers.Timer(1000);
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                }
                public static WriteDBMessage ReadWriteFifo(Mode mode, WriteDBMessage message)
                {
                    Object thisLock2 = new Object();
                    lock (thisLock2)
                    {
                        switch (mode)
                        {
                            case Mode.READ:
                                if (fifo.Count > 0)
                                {
                                    message = fifo[0];
                                    fifo.RemoveAt(0);
                                }
                                break;
                            case Mode.WRITE:
                                fifo.Add(message);
                                break;
                        }
                    }
                    return message;
                }
                static void Timer_Elapsed(object sender, ElapsedEventArgs e)
                {
                    timer.Enabled = false;
                    WriteDBMessage row = null;
                    int rowsAdded = 0;
                    uint number = 0;
                    try
                    {
                        while ((row = ReadWriteFifo(Mode.READ, null)) != null)
                        {
                            switch (row.message)
                            {
                                case DATABASE_MESSAGE_TYPE.LOGIN:
                                     cmdLogin.Parameters["@Date"].Value = ((WriteDBMessageLogin)row).date;
                                    rowsAdded = cmdLogin.ExecuteNonQuery();
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error : '{0}'", ex.Message);
                    }
                    timer.Enabled = true;
                }
            }
            public Server(string IP, int port, Boolean test)
            {
                try
                {
                    conn = new SqlConnection(CONNECT_STRING);
                    conn.Open();
                    cmdLogin = new SqlCommand(LOGIN_INSERT_COMMMAND_TEXT, conn);
                    cmdLogin.Parameters.Add("@TerminalID", SqlDbType.NVarChar, 8);
                    cmdLogin.Parameters.Add("@Date", SqlDbType.DateTime);
                    cmdLocation = new SqlCommand(LOCATION_INSERT_COMMMAND_TEXT, conn);
                    cmdLocation.Parameters.Add("@IMEI", SqlDbType.NVarChar, 50);
                    cmdLocation.Parameters.Add("@TrackTime", SqlDbType.DateTime);
                    cmdLocation.Parameters.Add("@currTime", SqlDbType.DateTime);
                    cmdLocation.Parameters.Add("@Longitude", SqlDbType.NChar, 50);
                    cmdLocation.Parameters.Add("@Lattitude", SqlDbType.NVarChar, 50);
                    cmdLocation.Parameters.Add("@speed", SqlDbType.Float);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : '{0}'", ex.Message);
                    //Console.ReadLine();
                    return;
                }
                try
                {
                    //initialize the timer for writing to database.
                    WriteDBAsync.WriteDatabase();
                    StartListening(IP, port, test);
                    // Open 2nd listener to simulate two devices, Only for testing
                    //StartListening(IP, port + 1, test);
                    ProcessMessages();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error : '{0}'", ex.Message);
                    //Console.ReadLine();
                    return;
                }
            }
            public void StartListening(string IP, int port, Boolean test)
            {
                try
                {
                    // Establish the local endpoint for the socket.
                    // The DNS name of the computer
                    // running the listener is "host.contoso.com".
                    IPHostEntry ipHostInfo = Dns.GetHostEntry(IP);  //Dns.Resolve(Dns.GetHostName());
                    IPAddress ipAddress = ipHostInfo.AddressList[0];
                    //IPAddress local = IPAddress.Parse(IP);
                    IPEndPoint localEndPoint = null;
                    if (test)
                    {
                        localEndPoint = new IPEndPoint(IPAddress.Any, port);
                    }
                    else
                    {
                        localEndPoint = new IPEndPoint(ipAddress, port);
                    }
                    // Create a TCP/IP socket.
                    Socket listener = new Socket(AddressFamily.InterNetwork,
                        SocketType.Stream, ProtocolType.Tcp);
                    // Bind the socket to the local endpoint and listen for incoming connections.
                    allDone.Reset();
                    acceptDone.Reset();
                    listener.Bind(localEndPoint);
                    listener.Listen(100);
                    //login code, wait for 1st message
                    Console.WriteLine("Wait 5 seconds for login message");
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public void ProcessMessages()
            {
                UInt16 sendCRC = 0;
                DateTime date;
                int year = 0;
                int month = 0;
                int day = 0;
                int hour = 0;
                int minute = 0;
                int second = 0;
                KeyValuePair<List<byte>, StateObject> byteState;
                KeyValuePair<UNPACK_STATUS, byte[]> status;
                byte[] receiveMessage = null;
                StateObject state = null;
                byte[] serialNumber = null;
                byte[] serverFlagBit = null;
                byte[] stringArray = null;
                string stringMessage = "";
                byte lengthOfCommand = 0;
                PROTOCOL_NUMBER protocolNumber = PROTOCOL_NUMBER.NONE;            
                try
                {
                    Boolean firstMessage = true;
                    acceptDone.Set();
                    //loop forever
                    while (true)
                    {
                        allDone.WaitOne();
                        //read fifo until empty
                        while (true)
                        {
                            //read one connection until buffer doesn't contain any more packets
                            byteState = ReadWrite(PROCESS_STATE.PROCESS, null, null, -1);
                            if (byteState.Value.fifoCount == -1) break;
                            state = byteState.Value;
                            while (true)
                            {
                                status = Unpack(byteState);
                                if (status.Key == UNPACK_STATUS.NOT_ENOUGH_BYTES)
                                    break;
                                if (status.Key == UNPACK_STATUS.ERROR)
                                {
                                    Console.WriteLine("Error : Bad Receive Message, Data");
                                    break;
                                }
                                //message is 2 start bytes + 1 byte (message length) + 1 byte message length + 2 end bytes
                                receiveMessage = status.Value;
                                int messageLength = receiveMessage[2];
                                Console.WriteLine("Status : '{0}', Receive Message : '{1}'", status.Key == UNPACK_STATUS.GOOD_MESSAGE ? "Good" : "Bad", BytesToString(receiveMessage.Take(messageLength + 5).ToArray()));
                                if (status.Key != UNPACK_STATUS.GOOD_MESSAGE)
                                {
                                    break;
                                }
                                else
                                {
                                    if (firstMessage)
                                    {
                                        if (receiveMessage[3] != 0x01)
                                        {
                                            Console.WriteLine("Error : Expected Login Message : '{0}'", BytesToString(receiveMessage));
                                            break;
                                        }
                                        firstMessage = false;
                                    }
                                    //skip start bytes, message length.  then go back 4 bytes (CRC and serial number)
                                    serialNumber = receiveMessage.Skip(2 + 1 + messageLength - 4).Take(2).ToArray();
                                    protocolNumber = (PROTOCOL_NUMBER)receiveMessage[3];
                                    Console.WriteLine("Protocol Number : '{0}'", protocolNumber.ToString());
                                    switch (protocolNumber)
                                    {
                                        case PROTOCOL_NUMBER.LOGIN_MESSAGE:
                                             break;
     
                                    } //end switch
                                }// End if
                            } //end while
                        }//end while fifo > 0
                        allDone.Reset();
                    }//end while true
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            static string BytesToString(byte[] bytes)
            {
                return string.Join("", bytes.Select(x => x.ToString("X2")));
            }
            static KeyValuePair<UNPACK_STATUS, byte[]> Unpack(KeyValuePair<List<byte>, StateObject> bitState)
            {
                List<byte> working_buffer = bitState.Key;
                //return null indicates an error
                if (working_buffer.Count() < 3) return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.NOT_ENOUGH_BYTES, null);
                int len = working_buffer[2];
                if (working_buffer.Count < len + 5) return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.NOT_ENOUGH_BYTES, null);
                // check start and end bytes
                // remove message fro workig buffer and dictionary 
                KeyValuePair<List<byte>, StateObject> byteState = ReadWrite(PROCESS_STATE.UNPACK, null, null, bitState.Value.connectionNumber);
                if (byteState.Key.Count == 0) return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.ERROR, null);
                List<byte> packet = byteState.Key;
                //crc test
                byte[] crc = packet.Skip(len + 1).Take(2).ToArray();
                ushort crcShort = (ushort)((crc[0] << 8) | crc[1]);
                //skip start bytes, crc, and end bytes
     
                return new KeyValuePair<UNPACK_STATUS, byte[]>(UNPACK_STATUS.GOOD_MESSAGE, packet.ToArray());
            }
            static KeyValuePair<List<byte>, StateObject> ReadWrite(PROCESS_STATE ps, Socket handler, IAsyncResult ar, long unpackConnectionNumber)
            {
                KeyValuePair<List<byte>, StateObject> byteState = new KeyValuePair<List<byte>, StateObject>(); ;
                StateObject stateObject = null;
                int bytesRead = -1;
                int workingBufferLen = 0;
                List<byte> working_buffer = null;
                byte[] buffer = null;
                Object thisLock1 = new Object();
                lock (thisLock1)
                {
                    switch (ps)
                    {
                        case PROCESS_STATE.ACCEPT:
                            acceptDone.WaitOne();
                            acceptDone.Reset();
                            stateObject = new StateObject();
                            stateObject.buffer = new byte[BUFFER_SIZE];
                            connectionDict.Add(connectionNumber, new KeyValuePair<List<byte>, StateObject>(new List<byte>(), stateObject));
                            stateObject.connectionNumber = connectionNumber++;
                            stateObject.workSocket = handler;
                            byteState = new KeyValuePair<List<byte>, StateObject>(null, stateObject);
                            acceptDone.Set();
                            break;
                        case PROCESS_STATE.READ:
                            //catch when client disconnects
                            //wait if accept is being called
                            //acceptDone.WaitOne();
                            try
                            {
                                stateObject = ar.AsyncState as StateObject;
                                // Read data from the client socket. 
                                bytesRead = stateObject.workSocket.EndReceive(ar);
                                if (bytesRead > 0)
                                {
                                    byteState = connectionDict[stateObject.connectionNumber];
                                    buffer = new byte[bytesRead];
                                    Array.Copy(byteState.Value.buffer, buffer, bytesRead);
                                    byteState.Key.AddRange(buffer);
                                }
                                //only put one instance of connection number into fifo
                                if (!fifo.Contains(byteState.Value.connectionNumber))
                                {
                                    fifo.Add(byteState.Value.connectionNumber);
                                }
                            }
                            catch (Exception ex)
                            {
                                //will get here if client disconnects
                                fifo.RemoveAll(x => x == byteState.Value.connectionNumber);
                                connectionDict.Remove(byteState.Value.connectionNumber);
                                byteState = new KeyValuePair<List<byte>, StateObject>(new List<byte>(), null);
                            }
                            break;
                        case PROCESS_STATE.PROCESS:
                            if (fifo.Count > 0)
                            {
                                //get message from working buffer
                                //unpack will later delete message
                                //remove connection number from fifo
                                // the list in the key in known as the working buffer
                                byteState = new KeyValuePair<List<byte>, StateObject>(connectionDict[fifo[0]].Key, connectionDict[fifo[0]].Value);
                                fifo.RemoveAt(0);
                                //put a valid value in fifoCount so -1 below can be detected.
                                byteState.Value.fifoCount = fifo.Count;
                            }
                            else
                            {
                                //getting here is normal when there is no more work to be performed
                                //set fifocount to zero so rest of code know fifo was empty so code waits for next receive message
                                byteState = new KeyValuePair<List<byte>, StateObject>(null, new StateObject() { fifoCount = -1 });
                            }
                            break;
                        case PROCESS_STATE.UNPACK:
                            try
                            {
                                working_buffer = connectionDict[unpackConnectionNumber].Key;
                                workingBufferLen = working_buffer[2];
                                if ((working_buffer[0] != 0x78) && (working_buffer[1] != 0x78) && (working_buffer[workingBufferLen + 3] != 0x0D) && (working_buffer[workingBufferLen + 4] != 0x0A))
                                {
                                    working_buffer.Clear();
                                    return new KeyValuePair<List<byte>, StateObject>(new List<byte>(), null);
                                }
                                List<byte> packet = working_buffer.GetRange(0, workingBufferLen + 5);
                                working_buffer.RemoveRange(0, workingBufferLen + 5);
                                byteState = new KeyValuePair<List<byte>, StateObject>(packet, null);
                            }
                            catch (Exception ex)
                            {
                                int testPoint = 0;
                            }
                            break;
                    }// end switch
                }
                return byteState;
            }
            public static void AcceptCallback(IAsyncResult ar)
            {
                try
                {
                    // Get the socket that handles the client request.
                    // Retrieve the state object and the handler socket
                    // from the asynchronous state object.
                    Socket listener = (Socket)ar.AsyncState;
                    Socket handler = listener.EndAccept(ar);
                    // Create the state object.
                    StateObject state = ReadWrite(PROCESS_STATE.ACCEPT, handler, ar, -1).Value;
                    handler.BeginReceive(state.buffer, 0, BUFFER_SIZE, 0,
                        new AsyncCallback(ReadCallback), state);
                }
                catch (Exception ex)
                {
                    int myerror = -1;
                }
            }
            public static void ReadCallback(IAsyncResult ar)
            {
                try
                {
                    StateObject state = ar.AsyncState as StateObject;
                    Socket handler = state.workSocket;
                    // Read data from the client socket. 
                    KeyValuePair<List<byte>, StateObject> byteState = ReadWrite(PROCESS_STATE.READ, handler, ar, -1);
                    if (byteState.Value != null)
                    {
                        allDone.Set();
                        handler.BeginReceive(state.buffer, 0, BUFFER_SIZE, 0,
                            new AsyncCallback(ReadCallback), state);
                    }
                    else
                    {
                        int testPoint = 0;
                    }
                }
                catch (Exception ex)
                {
                    int myerror = -1;
                }
                // Signal the main thread to continue.  
                allDone.Set();
            }
        }
    }
