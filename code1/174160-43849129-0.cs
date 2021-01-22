    using Shell32;
    static class Program
    {
        public static Shell shell = new Shell();
        public static Folder RecyclingBin = shell.NameSpace(10);
        static void Main()
        {
            RecyclingBin.MoveHere("PATH TO FILE/FOLDER")
        }
    }
