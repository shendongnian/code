    [StructLayout(LayoutKind.Sequential)]
    public struct WIN32_FILE_ATTRIBUTE_DATA
    {
        public uint fileAttributes;
        public System.Runtime.InteropServices.ComTypes.FILETIME creationTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME lastAccessTime;
        public System.Runtime.InteropServices.ComTypes.FILETIME lastWriteTime;
        public uint fileSizeHigh;
        public uint fileSizeLow;
    }
    public enum GET_FILEEX_INFO_LEVELS
    {
        GetFileExInfoStandard,
        GetFileExMaxInfoLevel
    }
    public class NativeMethods {
        [DllImport("KERNEL32.dll", CharSet = CharSet.Auto)]
        public static extern bool GetFileAttributesEx(string path, GET_FILEEX_INFO_LEVELS  level, out WIN32_FILE_ATTRIBUTE_DATA data);
    }
