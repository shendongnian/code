    public class Cleanuper
    {
        private void PendingDeleteDirectory(string directoryPath)
        {
            foreach (string directory in Directory.GetDirectories(directoryPath, "*", SearchOption.TopDirectoryOnly))
            {
                PendingDeleteDirectory(directory);
            }
            foreach (string file in Directory.GetFiles(directoryPath, "*", SearchOption.TopDirectoryOnly))
            {
                NativeMethods.MoveFileEx(file, null, MoveFileFlags.DelayUntilReboot);
            }
            NativeMethods.MoveFileEx(directoryPath, null, MoveFileFlags.DelayUntilReboot);
        }
    }
    public static class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool MoveFileEx(string lpExistingFileName, string lpNewFileName, MoveFileFlags dwFlags);
    }
    [Flags]
    public enum MoveFileFlags
    {
        DelayUntilReboot = 0x00000004
    }
