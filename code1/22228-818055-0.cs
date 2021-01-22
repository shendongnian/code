        [ComImport]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("6D67E846-5B9C-4db8-9CBC-DDE12F4254F1")]
        public interface ITrayDeskband
        {
            [PreserveSig]
            int ShowDeskBand(Guid clsid);
            [PreserveSig]
            int HideDeskBand(Guid clsid);
            [PreserveSig]
            int IsDeskBandShown(Guid clsid);
            [PreserveSig]
            int DeskBandRegistrationChanged();
        }
            ITrayDeskband obj = null;
            Type trayDeskbandType = System.Type.GetTypeFromCLSID(new Guid("E6442437-6C68-4f52-94DD-2CFED267EFB9"));
            try
            {
                obj = (ITrayDeskband)Activator.CreateInstance(trayDeskbandType);
                Guid deskbandGuid = new Guid(some deskband guid);
                obj.DeskBandRegistrationChanged();
                int hr = obj.ShowDeskBand(deskbandGuid);
                if (hr != 0) throw new Exception("Error while trying to show deskband: " + hr);
                obj.DeskBandRegistrationChanged();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                if (obj != null && Marshal.IsComObject(obj))
                    Marshal.ReleaseComObject(obj);
            }
