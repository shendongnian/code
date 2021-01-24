        public partial class Form1 : Form { 
        [DllImport(@"C:\Program Files (x86)\SELIAtec\UF01\UF01.dll", EntryPoint = "UF01_OpenDevices", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        unsafe static extern Boolean UF01_OpenDevices(ref byte devices);
        [DllImport(@"C:\Program Files (x86)\SELIAtec\UF01\UF01.dll", EntryPoint = "UF01_CloseAll", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        unsafe static extern void UF01_CloseAll();
        [DllImport(@"C:\Program Files (x86)\SELIAtec\UF01\UF01.dll", EntryPoint = "UF01_UD01_8Entrees", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        unsafe static extern Boolean UF01_UD01_8Entrees(byte Device, byte module, ref byte data);
        [DllImport(@"C:\Program Files (x86)\SELIAtec\UF01\UF01.dll", EntryPoint = "UF01_UD01_8Entrees", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        unsafe static extern Boolean UF01_GetInfosModule(byte Device, bool Watchdog, ref _UF01_INFORMATIONS infos);
        [DllImport(@"C:\Program Files (x86)\SELIAtec\UF01\UF01.dll", EntryPoint = "UF01_UA01_Entrees", CallingConvention = System.Runtime.InteropServices.CallingConvention.Winapi)]
        unsafe static extern Boolean UF01_UA01_Entrees(byte Device, byte Module, ref ushort[] TableData_12bit);
        public Form1()
        {
            InitializeComponent();
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct _UF01_INFORMATIONS
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Type;
            [MarshalAs(UnmanagedType.U1)]
            public byte Nombre_Module;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Nb_Voies;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public byte[] Modele;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public string[] Name;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            public string[] Comments;
            [MarshalAs(UnmanagedType.I1)]
            public bool UseInterrupt;
        }
        private unsafe void button1_Click(object sender, EventArgs e)
        {
            byte nb_Device = 0;
            ushort[] data = new ushort[8]; 
                       
            _UF01_INFORMATIONS m_infos = new _UF01_INFORMATIONS();
            m_infos.Type = new byte[8];
            m_infos.Nb_Voies = new byte[8];
            m_infos.Modele = new byte[8];
            m_infos.Name = new string[8];
            m_infos.Comments = new string[8];
            m_infos.Nombre_Module = 0;
            m_infos.UseInterrupt = false;
            if (UF01_OpenDevices(ref nb_Device))
            {
                this.label1.Text = "Nombre de CPU's : " + nb_Device;
                if (UF01_GetInfosModule(nb_Device, false, ref m_infos))
                    label2.Text = "Nombre de modules : " + m_infos.Nombre_Module.ToString();
                if (UF01_UA01_Entrees(nb_Device, 1, ref data))
                    label3.Text = "Donnee : " + data[0].ToString();
            }
        }
    }
