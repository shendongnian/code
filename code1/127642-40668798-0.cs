    namespace EraseJunkFiles
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryInfo yourRootDir = new DirectoryInfo(@"C:\somedirectory\");
                foreach (DirectoryInfo dir in yourRootDir.GetDirectories())
                        DeleteDirectory(dir.FullName, true);
            }
            public static void DeleteDirectory(string directoryName, bool checkDirectiryExist)
            {
                if (Directory.Exists(directoryName))
                    Directory.Delete(directoryName, true);
                else if (checkDirectiryExist)
                    throw new SystemException("Directory you want to delete is not exist");
            }
        }
    }
