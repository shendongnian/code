    /// <summary>
    /// This namespace provides a crossthread-, concurrentproof buffer manager. 
    /// </summary>
    namespace YariIfStream
    {
        /// <summary>
        /// A class that manages three buffers used for IF data streams
        /// </summary>
        public class YariIFStream
        {
            private byte[] writebuf; ///<value>The buffer used for writing</value>
            private byte[] readbuf; ///<value>The buffer used for reading</value>
            private byte[] swapbuf; ///<value>The buffer used for swapping</value>
            private bool firsttime; ///<value>Boolean used for checking if it is the first time a writebuffers is asked</value>
            private Object sync; ///<value>Object used for syncing</value>
            /// <summary>
            /// Initializes a new instance of the Yari.YariIFStream class with expandable buffers with a initial capacity as specified
            /// </summary>
            /// <param name="capacity">Initial capacity of the buffers</param>
            public YariIFStream(int capacity)
            {
                sync = new Object();
                firsttime = true;
                writebuf = new byte[capacity];
                readbuf = new byte[capacity];
                swapbuf = new byte[capacity];
            }
            /// <summary>
            /// Returns the buffer with new data ready to be read
            /// </summary>
            /// <returns>byte[]</returns>
            public byte[] GetReadBuffer()
            {
                byte[] tempbuf;
                lock (sync)
                {
                    Monitor.Wait(sync);
                    tempbuf = swapbuf;
                    swapbuf = readbuf;
                }
                readbuf = tempbuf;
                return readbuf;
            }
            /// <summary>
            /// Returns the buffer ready to be written with data
            /// </summary>
            /// <returns>byte[]</returns>
            public byte[] GetWriteBuffer()
            {
                byte[] tempbuf;
                lock (sync)
                {
                    tempbuf = swapbuf;
                    swapbuf = writebuf;
                    writebuf = tempbuf;
                    if (!firsttime)
                    {
                        Monitor.Pulse(sync);
                    }
                    else
                    {
                        firsttime = false;
                    }
                }
                return writebuf;
            }
        }
    }
