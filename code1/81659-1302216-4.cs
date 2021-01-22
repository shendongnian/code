    public class WindowsPlatformServices : IPlatformServices
    {
        // Prevent early type initialization
        static WindowsPlatformServices() {}
        public const Int32 SystemMenuAboutSWikiId = 1000;
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, 
                                              Int32 wFlags, Int32 wIDNewItem,
                                              string lpNewItem);
        public void InitializeSystemMenu()
        {
            const Int32 MF_SEPARATOR = 0x800;
            const Int32 MF_BYPOSITION = 0x400;
            IntPtr systemMenuPtr = GetSystemMenu(Handle, false);
            InsertMenu(systemMenuPtr, 5, MF_BYPOSITION | MF_SEPARATOR, 0, "");
            InsertMenu(systemMenuPtr, 6, MF_BYPOSITION, SystemMenuAboutSWikiId, 
                       "About SWiki...");
        }
    }
