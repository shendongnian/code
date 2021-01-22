using System;
using System.IO;
namespace YourNamespace
{
    public static class DirectoryInfoExtensions
    {
        public static void EmptyDirectory(this DirectoryInfo di)
        {
            if (di.Exists)
            {
                foreach (var file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (var directory in di.GetDirectories())
                {
                    directory.Delete(true);
                }
            }
        }
    }
}
