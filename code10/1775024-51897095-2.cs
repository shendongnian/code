    using System;
    using System.Collections.Generic;
    using Microsoft.Win32.SafeHandles;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.IO;
    
    namespace NamedPipe
    {
        public class NamedPipeServer
        {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern SafeFileHandle CreateNamedPipe(
           String sPipeName,
           uint dwOpenMode,
           uint dwPipeMode,
           uint nMaxInstances,
           uint nOutBufferSize,
           uint nInBufferSize,
           uint nDefaultTimeOut,
           IntPtr lpSecurityAttributes);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int ConnectNamedPipe(SafeFileHandle hNamedPipe, IntPtr lpOverlapped);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int DisconnectNamedPipe(SafeFileHandle hNamedPipe);
        public const uint DUPLEX = (0x00000003);
        public const uint FILE_FLAG_OVERLAPPED = (0x40000000);
        public List<string> m_ReceivedValues = new List<string>();
        public class Client
        {
            public SafeFileHandle handle;
            public FileStream stream;
        }
        public const int BUFFER_SIZE = 100;
        public Client m_clientse = null;
        public string m_sPipeName;
        Thread m_listenThread;
        SafeFileHandle m_clientHandle;
        public NamedPipeServer(string PName)
        {
            m_sPipeName = PName;
        }
        public void Start()
        {
            m_listenThread = new Thread(new ThreadStart(ListenForClients));
            m_listenThread.Start();
        }
        private void ListenForClients()
        {
            while (true)
            {
                m_clientHandle = CreateNamedPipe(m_sPipeName, DUPLEX | FILE_FLAG_OVERLAPPED, 0, 255, BUFFER_SIZE, BUFFER_SIZE, 0, IntPtr.Zero);
                if (m_clientHandle.IsInvalid)
                    return;
                int success = ConnectNamedPipe(m_clientHandle, IntPtr.Zero);
                if (success == 0)
                    return;
                m_clientse = new Client();
                m_clientse.handle = m_clientHandle;
                m_clientse.stream = new FileStream(m_clientse.handle, FileAccess.ReadWrite, BUFFER_SIZE, true);
                Thread readThread = new Thread(new ThreadStart(Read));
                readThread.Start();
            }
        }
        private void Read()
        {
            byte[] buffer = null;
            ASCIIEncoding encoder = new ASCIIEncoding();
            while (true)
            {
                int bytesRead = 0;
                try
                {
                    buffer = new byte[BUFFER_SIZE];
                    bytesRead = m_clientse.stream.Read(buffer, 0, BUFFER_SIZE);
                }
                catch
                {
                    //read error has occurred
                    break;
                }
                //client has disconnected
                if (bytesRead == 0)
                    break;
                int ReadLength = 0;
                for (int i = 0; i < BUFFER_SIZE; i++)
                {
                    if (buffer[i].ToString("x2") != "cc")
                    {
                        ReadLength++;
                    }
                    else
                        break;
                }
                if (ReadLength > 0)
                {
                    byte[] Rc = new byte[ReadLength];
                    Buffer.BlockCopy(buffer, 0, Rc, 0, ReadLength);
                    string sReadValue = encoder.GetString(Rc, 0, ReadLength);                    
                    string[] codeInfo = sReadValue.Split('-');
                    if (codeInfo.Length == 2)
                    {
                        string sSize = codeInfo[0];
                        string sCode = codeInfo[1];
                        string sFinalValue = sCode;
                        int nSize = Int32.Parse(sSize);
                        if (sCode.Length >= nSize)
                        {
                            sFinalValue = sCode.Substring(0, nSize);
                        }
                        m_ReceivedValues.Add(sFinalValue);
                        Console.WriteLine($"C# App: Received value : {sFinalValue}");
                        buffer.Initialize();
                    }
                    else
                    {
                        Console.WriteLine("C# App: Received value in named pipe is badly formatted (we expect 'size-code')");
                    }
                }
            }
            m_clientse.stream.Close();
            m_clientse.handle.Close();
        }
        public void StopServer()
        {
            DisconnectNamedPipe(m_clientHandle);
            m_listenThread.Abort();
        }
      }
    }
