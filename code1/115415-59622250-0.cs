    [DllImport("gdi32.dll")]
    private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
     
        PrivateFontCollection pFC = new PrivateFontCollection();
            try
            {
                string[] resource = { "newFont-Bold.ttf", "newFont-Regular.ttf" }; // specify embedded resource name
                foreach (var item in resource)
                {
                    // receive resource stream
                    Stream fontStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(item);
                    // create an unsafe memory block for the font data
                    System.IntPtr data = Marshal.AllocCoTaskMem((int)fontStream.Length);
                    // create a buffer to read in to
                    byte[] fontdata = new byte[fontStream.Length];
                    // read the font data from the resource
                    fontStream.Read(fontdata, 0, (int)fontStream.Length);
                    // copy the bytes to the unsafe memory block
                    Marshal.Copy(fontdata, 0, data, (int)fontStream.Length);
                    ///IMPORTANT line to register font in system
                    uint cFonts = 0;
                    AddFontMemResourceEx(data, (uint)fontdata.Length, IntPtr.Zero, ref cFonts);
                    // pass the font to the font collection
                    pFC.AddMemoryFont(data, (int)fontStream.Length);
                    // close the resource stream
                    fontStream.Close();
                    // free up the unsafe memory
                    Marshal.FreeCoTaskMem(data);
                }
            }
            catch (Exception exp)
            {
                Log.Error(exp);
            }
            return pFC;
