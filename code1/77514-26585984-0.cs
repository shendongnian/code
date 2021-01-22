    public static void RevokeCert(string connection,string serial)
    {
        //connection= "192.168.71.128\\My-CA"
        //serial = "614870cd000000000014"
        const int CRL_REASON_UNSPECIFIED = 0;
        CERTADMINLib.CCertAdmin _admin = null;
        try
        {
            _admin = new CCertAdmin();
            _admin.RevokeCertificate(connection, serial, CRL_REASON_UNSPECIFIED, DateTime.Now);
        }
        finally
        {
            if (_admin != null)
                Marshal.FinalReleaseComObject(_admin);
        }
    }
