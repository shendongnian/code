        public static void ScreenCapture(string filename)
        {
            // Initialize the virtual screen to dummy values
            int screenLeft = int.MaxValue;
            int screenTop = int.MaxValue;
            int screenRight = int.MinValue;
            int screenBottom = int.MinValue;
            // Enumerate system display devices
            int deviceIndex = 0;
            while (true)
            {
                NativeUtilities.DisplayDevice deviceData = new NativeUtilities.DisplayDevice{cb = Marshal.SizeOf(typeof(NativeUtilities.DisplayDevice))};
                if (NativeUtilities.EnumDisplayDevices(null, deviceIndex, ref deviceData, 0) != 0)
                {
                    // Get the position and size of this particular display device
                    NativeUtilities.DEVMODE devMode = new NativeUtilities.DEVMODE();
                    if (NativeUtilities.EnumDisplaySettings(deviceData.DeviceName, NativeUtilities.ENUM_CURRENT_SETTINGS, ref devMode))
                    {
                        // Update the virtual screen dimensions
                        screenLeft = Math.Min(screenLeft, devMode.dmPositionX);
                        screenTop = Math.Min(screenTop, devMode.dmPositionY);
                        screenRight = Math.Max(screenRight, devMode.dmPositionX + devMode.dmPelsWidth);
                        screenBottom = Math.Max(screenBottom, devMode.dmPositionY + devMode.dmPelsHeight);
                    }
                    deviceIndex++;
                }
                else
                    break;
            }
            // Create a bitmap of the appropriate size to receive the screen-shot.
            using (Bitmap bmp = new Bitmap(screenRight - screenLeft, screenBottom - screenTop))
            {
                // Draw the screen-shot into our bitmap.
                using (Graphics g = Graphics.FromImage(bmp))
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                // Stuff the bitmap into a file
                bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
