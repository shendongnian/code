            SMB_COM_CREATE_DIRECTORY = 0x00,
            SMB_COM_DELETE_DIRECTORY = 0x01,
            SMB_COM_OPEN = 0x02,
            SMB_COM_CREATE = 0x03,
            SMB_COM_CLOSE = 0x04,
            SMB_COM_FLUSH = 0x05,
            SMB_COM_DELETE = 0x06,
            SMB_COM_RENAME = 0x07,
            SMB_COM_QUERY_INFORMATION = 0x08,
            SMB_COM_SET_INFORMATION = 0x09,
            SMB_COM_READ = 0x0A,
            SMB_COM_WRITE = 0x0B,
            SMB_COM_LOCK_BYTE_RANGE = 0x0C,
            SMB_COM_UNLOCK_BYTE_RANGE = 0x0D,
            SMB_COM_CREATE_TEMPORARY = 0x0E,
            SMB_COM_CREATE_NEW = 0x0F,
            SMB_COM_CHECK_DIRECTORY = 0x10,
            SMB_COM_PROCESS_EXIT = 0x11,
            SMB_COM_SEEK = 0x12,
            SMB_COM_LOCK_AND_READ = 0x13,
            SMB_COM_WRITE_AND_UNLOCK = 0x14,
            SMB_COM_READ_RAW = 0x1A,
            SMB_COM_READ_MPXv0x1B,
            SMB_COM_READ_MPX_SECONDARY = 0x1C,
            SMB_COM_WRITE_RAW = 0x1D,
            SMB_COM_WRITE_MPX = 0x1E,
            SMB_COM_WRITE_MPX_SECONDARY = 0x1F,
            SMB_COM_WRITE_COMPLETE = 0x20,
            SMB_COM_QUERY_SERVER = 0x21,
            SMB_COM_SET_INFORMATION2 = 0x22,
            SMB_COM_QUERY_INFORMATION2 = 0x23,
            SMB_COM_LOCKING_ANDX = 0x24,
            SMB_COM_TRANSACTION = 0x25,
            SMB_COM_TRANSACTION_SECONDARY = 0x26,
            SMB_COM_IOCTL = 0x27,
            SMB_COM_IOCTL_SECONDARY = 0x28,
            SMB_COM_COPY = 0x29,
            SMB_COM_MOVE = 0x2A,
            SMB_COM_ECHO = 0x2B,
            SMB_COM_WRITE_AND_CLOSE = 0x2C,
            SMB_COM_OPEN_ANDX = 0x2D,
            SMB_COM_READ_ANDX = 0x2E,
            SMB_COM_WRITE_ANDX = 0x2F,
            SMB_COM_NEW_FILE_SIZE = 0x30,
            SMB_COM_CLOSE_AND_TREE_DISC = 0x31,
            SMB_COM_TRANSACTION2 = 0x32,
            SMB_COM_TRANSACTION2_SECONDARY = 0x33,
            SMB_COM_FIND_CLOSE2 = 0x34,
            SMB_COM_FIND_NOTIFY_CLOSE = 0x35,
            /* Used by Xenix/Unix 0x60 � 0x6E */
            SMB_COM_TREE_CONNECT = 0x70,
            SMB_COM_TREE_DISCONNECT = 0x71,
            SMB_COM_NEGOTIATE = 0x72,
            SMB_COM_SESSION_SETUP_ANDX = 0x73,
            SMB_COM_LOGOFF_ANDX = 0x74,
            SMB_COM_TREE_CONNECT_ANDX = 0x75,
            SMB_COM_QUERY_INFORMATION_DISK = 0x80,
            SMB_COM_SEARCH = 0x81,
            SMB_COM_FIND = 0x82,
            SMB_COM_FIND_UNIQUE = 0x83,
            SMB_COM_FIND_CLOSE = 0x84,
            SMB_COM_NT_TRANSACT = 0xA0,
            SMB_COM_NT_TRANSACT_SECONDARY = 0xA1,
            SMB_COM_NT_CREATE_ANDX = 0xA2,
            SMB_COM_NT_CANCEL = 0xA4,
            SMB_COM_NT_RENAME = 0xA5,
            SMB_COM_OPEN_PRINT_FILE = 0xC0,
            SMB_COM_WRITE_PRINT_FILE = 0xC1,
            SMB_COM_CLOSE_PRINT_FILE = 0xC2,
            SMB_COM_GET_PRINT_QUEUE = 0xC3,
            SMB_COM_READ_BULK = 0xD8,
            SMB_COM_WRITE_BULK = 0xD9,
            SMB_COM_WRITE_BULK_DATA = 0xDA
        }
       
        public struct CIFSPacket
        {
            public uint protocolIdentifier;//the value must be "0xFF+'SMB'"
            public byte command;
            public byte errorClass;
            public byte reserved;
            public ushort error;
            public byte flags;
            //here there are 14 bytes of data which is used differently among different dialects.
            //I do want the flags2 however so I'll try parsing them
            public ushort flags2;
            public ushort treeId;
            public ushort processId;
            public ushort userId;
            public ushort multiplexId;
            //trans request
            public byte wordCount;//Count of parameter words defining the data portion of the packet.
            //from here it might be undefined...
            public int parametersStartIndex;
            public ushort byteCount;//buffer length
            public int bufferStartIndex;
           // [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)] 
            public string Buffer;
          
        }
         static void Main(string[] args)
        {
            
              sock = new Socket(AddressFamily.InterNetwork,  
             SocketType.Stream, ProtocolType.Tcp); 
                   // create server IPEndPoint instance. We assume  
                   //GetHostEntry returns at least one address 
              IPAddress server = IPAddress.Parse("172.24.18.240");
              int servPort = 139;
               
                 IPEndPoint serverEndPoint = new IPEndPoint(Dns.GetHostEntry(server).AddressList[0], servPort);
                  // CONNECT THE SOCKET TO THE SERVER ON SPECIFIED PORT
                   sock.Connect(serverEndPoint); 
                 
                  /// SocketOptionLevel Tcp = new SocketOptionLevel();   
                   sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                 
                  
                   CIFSPacket packet = new CIFSPacket();
                   packet.protocolIdentifier = 0xff;
                   packet.command = (byte)CommandTypes.SMB_COM_NEGOTIATE;
                   packet.errorClass = 0xff;
                   packet.error = 0;
                   packet.flags = 0x00;
                   packet.flags2 = 0x0001;
                   packet.multiplexId = 22;
                   packet.wordCount = 100;
                   packet.Buffer = "NT LM 0.12";
                   packet.byteCount = (ushort)packet.Buffer.Length;
                   //System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                   // Byte[] bytes = encoding.GetBytes(packet.ToString());
                   int len = Marshal.SizeOf(packet);
                   byte[] arr = new byte[len];
                   IntPtr ptr = Marshal.AllocHGlobal(len);
                   Marshal.StructureToPtr(packet, ptr, true);
                   Marshal.Copy(ptr, arr, 0, len);
                   Marshal.FreeHGlobal(ptr);
                   //Byte[] bite = null;
                   //bite = BitConverter.GetBytes(Convert.ToDouble(packet));
                   sock.Send(arr);
                   Thread thread = new Thread(new ThreadStart(WorkThreadFunction));
                   thread.Start();
                  // Console.WriteLine ("Connected to server... SENDING ECHO STRING");
                   //Console.ReadLine();   
        }
        public static void WorkThreadFunction()
        {
            byte[] buffer = new byte[1024];
            try
            {
                int iRx = sock.Receive(buffer);
            }
            catch (Exception ex)
            {
            }
        }
