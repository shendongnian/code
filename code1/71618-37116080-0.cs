        [DllImport("shell32.dll")]
        public static extern IntPtr ExtractIcon(IntPtr hInst, string file, int nIconIndex);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool DestroyIcon(IntPtr hIcon);
        /// <summary>
        /// Gets application icon from main .exe.
        /// </summary>
        /// <param name="setToObject">object to which to set up icon</param>
        /// <param name="bAsImageSource">true if get it as "ImageSource" (xaml technology), false if get it as "Icon" (winforms technology)</param>
        /// <returns>true if successful.</returns>
        public bool GetIcon(object setToObject, bool bAsImageSource)
        {
            String path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(path, "yourmainexecutableName.exe");
            int iIconIndex = 0;
            // If your application contains multiple icons, then
            // you could change iIconIndex here.
            object o2set = null;
            IntPtr hIcon = ExtractIcon(IntPtr.Zero, path, iIconIndex);
            if (hIcon == IntPtr.Zero)
                return false;
            Icon icon = (Icon)Icon.FromHandle(hIcon);
            if (bAsImageSource)
            {
                o2set = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    icon.ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, 
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            } else {
                icon = (Icon)icon.Clone();
            }
         
            DestroyIcon(hIcon);
            setToObject.GetType().GetProperty("Icon").SetValue(setToObject, o2set);
            return true;
        } //GetIcon
