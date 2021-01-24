    public static class GlobalVariables
    {
        private static string _filePath;
        public static string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; NotifyPropertyChanged(); }
        }
        private static string _fileName;
        public static string FileName
        {
            get { return _fileName; }
            set { _fileName = value; NotifyPropertyChanged(); }
        }
        public static event PropertyChangedEventHandler PropertyChanged;
        private static void NotifyPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
    }
