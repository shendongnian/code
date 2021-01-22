        static void SetAsDefaultPrinter(string printerDevice)
        {
            foreach (var printer in PrinterSettings.InstalledPrinters)
            {
                //verify that the printer exists here
            }
            var path = "win32_printer.DeviceId='" + printerDevice + "'";
            using (var printer = new ManagementObject(path))
            {
                printer.InvokeMethod("SetDefaultPrinter",
                                     null, null);
            }
            return;
        }
