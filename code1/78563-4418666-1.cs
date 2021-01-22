    class Program
    {
        static void Main(string[] args)
        {
            string target = “\FlashFX Disk\ARMv4i\conmanclient2.exe”;
            var version = NativeFile.GetFileInfo(target);
            Console.WriteLine(string.Format(“File: { 0}”, Path.GetFileName(target)));
            Console.WriteLine(string.Format(“Version: { 0}”, version.Version.ToString(4)));
            foreach (var key in version.StringTable.AllKeys)
            {
                Console.WriteLine(string.Format(“{ 0}: { 1}”, key, version.StringTable[key]));
            }
            Console.ReadLine();
        }
