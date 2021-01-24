    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    public enum FolderCustomSettingsMask : uint
    {
        InfoTip = 0x00000004,
        Clsid = 0x00000008,
        IconFile = 0x00000010,
        Logo = 0x00000020,
        Flags = 0x00000040
    }
    public enum FolderCustomSettingsRW : uint
    {
        Read = 0x00000001,
        ForceWrite = 0x00000002,
        ReadWrite = Read | ForceWrite
    }
    [SecurityCritical]
    [DllImport("Shell32.dll", CharSet = CharSet.Auto)]
    static extern uint SHGetSetFolderCustomSettings(ref SHFOLDERCUSTOMSETTINGS pfcs, string pszPath, FolderCustomSettingsRW dwReadWrite);
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    struct SHFOLDERCUSTOMSETTINGS
    {
        public uint dwSize;
        public FolderCustomSettingsMask dwMask;
        public IntPtr pvid;
        public string pszWebViewTemplate;
        public uint cchWebViewTemplate;
        public string pszWebViewTemplateVersion;
        public string pszInfoTip;
        public uint cchInfoTip;
        public IntPtr pclsid;
        public uint dwFlags;
        public string pszIconFile;
        public uint cchIconFile;
        public int iIconIndex;
        public string pszLogo;
        public uint cchLogo;
    }
    static void Main(string[] args)
    {
        string CurrentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string IconsFolder = args.Length > 0 ? args[0] : Path.Combine(CurrentPath, @"icons");
        UpdateFolderIcons(CurrentPath, IconsFolder);
        Console.WriteLine($"Press any key to terminate...");
        Console.ReadKey();
    }
    [SecuritySafeCritical]
    public static void UpdateFolderIcons(string BaseFolder, string IconsFolder)
    {
        Console.WriteLine($"Current path: {BaseFolder}");
        Console.WriteLine($"Processing...");
        Console.WriteLine();
        List<string> ExcludeDirList = new List<string>() {BaseFolder, IconsFolder};
        List<string> DirList = Directory.GetDirectories(BaseFolder, "*", SearchOption.AllDirectories).ToList();
        DirList = DirList.Except(ExcludeDirList).ToList();
        if (DirList.Count == 0) {
            Console.WriteLine($"No directories found!");
            return;
        }
        Console.WriteLine($"{DirList.Count} Directories found");
        Console.WriteLine("Updating...");
        Console.WriteLine();
        int UpdateCount = 0;
        List<string> IconNames = Directory.GetFiles(Path.Combine(BaseFolder, IconsFolder), "*").ToList();
        if (IconNames.Count == 0) {
            Console.WriteLine($"No icons found in {IconsFolder}");
            return;
        }
        foreach (string sPath in DirList)
        {
            string IconName = IconNames[random.Next(0, IconNames.Count)];
            SHFOLDERCUSTOMSETTINGS FolderSettings = new SHFOLDERCUSTOMSETTINGS  {
                dwMask = FolderCustomSettingsMask.IconFile,
                pszIconFile = IconName,
                iIconIndex = 0
            };
            uint hResult = SHGetSetFolderCustomSettings(
                ref FolderSettings, sPath + char.MinValue, FolderCustomSettingsRW.ForceWrite);
            UpdateCount += 1;
        }
        Console.WriteLine($"{UpdateCount} Files Updated");
        Console.WriteLine();
    }
