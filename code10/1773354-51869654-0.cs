      public class StorageImage : Image
    {
        public static string FolderName = "assest";
        public new object Source
        {
            get
            {
                return (ImageSource)base.Source;
            }
            set
            {
                base.Source = (ImageSource)ConvertFromInvariantString(value as string);
            }
        }
        public static object ConvertFromInvariantString(string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value)) return null;
                return ImageSource.FromFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FolderName, value));
            }
            catch (Exception ee)
            {
                return null;
            }
        }
    }
