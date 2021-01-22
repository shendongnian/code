        public static void EnableMouse(bool enable)
        {
            // every type of device has a hard-coded GUID, this is the one for mice
            Guid mouseGuid = new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}");
            
            // get this from the properties dialog box of this device in Device Manager
            string instancePath = @"ACPI\PNP0F03\4&3688D3F&0";
            
            DeviceHelper.SetDeviceEnabled(mouseGuid, instancePath, enable);
        }
