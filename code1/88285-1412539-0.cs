     static void Main()
        {
            try
            {
                DriveInfo driveInfo = new DriveInfo(@"C:");
                long FreeSpace = driveInfo.AvailableFreeSpace;
            }
            catch (System.IO.IOException errorMesage)
            {
                Console.WriteLine(errorMesage);
            }
             
        }
