        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("4CF504B0-DE96-11D0-8B3F-00A0C911E8E5")]
        public interface IBandSite
        {
            [PreserveSig]
            uint AddBand([In, MarshalAs(UnmanagedType.IUnknown)] Object pUnkSite);
            [PreserveSig]
            void RemoveBand(uint dwBandID);
        }
    
        private uint AddDeskbandToTray(Guid Deskband)
        {
            Guid IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");
            Guid ITrayBand = new Guid("{F60AD0A0-E5E1-45cb-B51A-E15B9F8B2934}");   
            Type TrayBandSiteService = Type.GetTypeFromCLSID(ITrayBand, true);
            IBandSite BandSite = Activator.CreateInstance(TrayBandSiteService) as IBandSite;
            object DeskbandObject = CoCreateInstance(Deskband, null, CLSCTX.CLSCTX_INPROC_SERVER, IUnknown);
            return BandSite.AddBand(DeskbandObject);
        }
