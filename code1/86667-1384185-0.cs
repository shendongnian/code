    public static class DirectoryInfoExtender
    {
        public static string ToString(this DirectoryInfo d, string format, int fractionalDigits)
        {
            double fileSize = GetDirectorySize(d);
            return FileSizeConverter.GetFileSizeString(fileSize, format, fractionalDigits);
        }
    
        public static double GetDirectorySize(DirectoryInfo d)
        {    
            var files = d.GetFiles();
            var directories = d.GetDirectories();
    
            if(files.Length == 0 && directories.Length == 0)
            {
                return 0;
            }
            else
            {
                double size = 0;
    
                foreach(var file in files)
                {
                    size += file.Length;
                }
    
                foreach(var directory in directories)
                {
                    size += GetDirectorySize(directory);
                }
            }
    
            return size;
        }
    }
    
    
    public static class FileInfoExtender
    {
        public static string ToString(this FileInfo f, string format, int fractionalDigits)
        {
            return FileSizeConverter.GetFileSizeString(f.Length, format, fractionalDigits);
        }
    }
    
    public class FileSizeConverter
    {
        public static string GetFileSizeString(double fileSize, string format, int fractionalDigits)
        {
            long divisor;
            string sizeIndicator;
    
            switch(format.ToLower().Trim())
            {
                case "gb":
                    divisor = (long)Math.Pow(2, 30);
                    sizeIndicator = "gigabytes";
                    break;
                case "mb":
                    divisor = (long) Math.Pow(2, 20);
                    sizeIndicator = "megabytes";
                    break;
                case "kb":
                    divisor = (long)Math.Pow(2, 10);
                    sizeIndicator = "kilobytes";
                    break;
                default:
                    divisor = 1;
                    sizeIndicator = "bytes";
                    break;
            }
            
            return String.Format("{0:N" + fractionalDigits +"} {1}", fileSize / divisor, sizeIndicator);
        }
    }
