    public class GetVerNum
    {
        static void Main(String[] args)
        {
            if (args.Length == 0)
                return;
            try
            {
                FileVersionInfo ver = FileVersionInfo.GetVersionInfo(args[0]);
                String version = "v" + ver.FileMajorPart.ToString() + "." + ver.FileMinorPart;
                if (ver.FileBuildPart > 0 || ver.FilePrivatePart > 0)
                    version += "." + ver.FileBuildPart;
                if (ver.FilePrivatePart > 0)
                    version += "." + ver.FilePrivatePart;
                Console.Write(version);
            }
            catch { }
        }
    }
