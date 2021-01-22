    using System.Drawing;
    
    class Class1
    {
        public static void Main()
        {
            var filePath =  @"C:\myfile.exe";
            var theIcon = IconFromFilePath(filePath);
    
            if (theIcon != null)
            {
                // Save it to disk, or do whatever you want with it.
                using (var stream = new System.IO.FileStream(@"c:\myfile.ico", System.IO.FileMode.CreateNew))
                {
                    theIcon.Save(stream);
                }
            }
        }
    
        public static Icon IconFromFilePath(string filePath)
        {
            var result = (Icon)null;
    
            try
            {
                result = Icon.ExtractAssociatedIcon(filePath);
            }
            catch (System.Exception)
            {
                // swallow and return nothing. You could supply a default Icon here as well
            }
    
            return result;
        }
    }
