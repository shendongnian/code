    class RAS
    {
        #region <Fields>
        private int rasConnectionsAmount; // ilość struktur typu RASCONN
        #endregion
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        static extern bool InternetGetConnectedState(
            ref int lpdwFlags,
            int dwReserved);
        const int MAX_PATH = 260;
        const int RAS_MaxDeviceType = 16;
        const int RAS_MaxPhoneNumber = 128;
        const int RAS_MaxEntryName = 256;
        const int RAS_MaxDeviceName = 128;
        const int RAS_Connected = 0x2000;
        /// <summary>
        /// Wykazuje wszystkie połączenia RAS.
        /// </summary>
        [DllImport("rasapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int RasEnumConnections([In, Out] RASCONN[] lprasconn, ref int lpcb,ref int lpcConnections);
        [DllImport("rasapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern uint RasHangUp(IntPtr hRasConn);
        [DllImport("RASAPI32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int RasGetConnectStatus(IntPtr hrasconn, ref RASCONNSTATUS lprasconnstatus);
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct RASCONN
        {
            public int dwSize;
            public IntPtr hrasconn;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxEntryName + 1)]
            public string szEntryName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceType + 1)]
            public string szDeviceType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceName + 1)]
            public string szDeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szPhonebook;
            public int dwSubEntry;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct RASCONNSTATUS
        {
            public int dwSize;
            public int rasconnstate;
            public int dwError;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceType + 1)]
            public string szDeviceType;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxDeviceName + 1)]
            public string szDeviceName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = RAS_MaxPhoneNumber + 1)]
            public string szPhoneNumber;
        }
        /// <summary>
        /// Pobranie wszystkich połączeń RAS.
        /// </summary>
        /// <returns>Struktury połączeń RAS</returns>
        private RASCONN[] GetRasConnections()
        {
            // Stworzenie tablicy, którą później należy przekazać funkcjom
            int rasEnumReturn;
            RASCONN[] rasconnStructs = new RASCONN[256];
            rasconnStructs.Initialize(); // inicjalizacja wszystkich pól struktury
            rasconnStructs[0].dwSize = Marshal.SizeOf(typeof(RASCONN)); // inicjalizacja pierwszego pola pierwszej struktury na wartość wielkości tej struktury
            int sizeOfRasconnStruct = rasconnStructs[0].dwSize * rasconnStructs.Length; // wielkość pojedynczej struktury * ilosc
            // Wywołanie RasEnumConnections do zdobycia wszystkich aktywnych połączeń RAS
            rasEnumReturn = RasEnumConnections(rasconnStructs, ref sizeOfRasconnStruct, ref rasConnectionsAmount);
            // jeżeli RasEnumConnections nie zwróciło ERROR_SUCCESS
            if (rasEnumReturn != 0) throw new Win32Exception(rasEnumReturn);
            return rasconnStructs;
        }
        /// <summary>
        /// Rozłącza internet.
        /// </summary>
        public void Disconnect()
        {
            RASCONN[] rasStructs = GetRasConnections();
            // Przejście przez każdą strukturę RASCONN
            for (int i = 0; i < rasConnectionsAmount; i++)
            {
                // Pobranie pojedynczej struktury
                RASCONN rStruct = rasStructs[i];
                // Jeżeli uchwyt do połączenia wynosi 0, to brak połączenia
                if (rStruct.hrasconn == IntPtr.Zero) continue; // i następna struktura...
                // Rozłączenie...
                RasHangUp(rStruct.hrasconn);
            }
        }
        public void Connect()
        {
            // TODO
        }
        public bool IsConnected()
        {
            RASCONN[] rasStructs = GetRasConnections();
            RASCONNSTATUS rasConnStatus = new RASCONNSTATUS();
            rasConnStatus.dwSize = Marshal.SizeOf(typeof(RASCONNSTATUS));
            for (int i = 0; i < rasConnectionsAmount; ++i)
            {
                // Pobranie pojedynczej struktury
                RASCONN rStruct = rasStructs[i];
                int statusResult = RasGetConnectStatus(rStruct.hrasconn, ref rasConnStatus);
                if (statusResult != 0) throw new Win32Exception(statusResult);
                if(rasConnStatus.rasconnstate == RAS_Connected) return true;
            }
            return false;
        }
    }
}
