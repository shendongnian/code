    class PathToThumbnailConverter : IValueConverter {
        public int DecodeWidth {
            get;
            set;
        }
        public PathToThumbnailConverter() {
            DecodeWidth = 200;
        }
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            var path = value as string;
            if ( !string.IsNullOrEmpty( path ) ) {
                FileInfo info = new FileInfo( path );
                if ( info.Exists && info.Length > 0 ) {
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.DecodePixelWidth = DecodeWidth;
                    bi.CacheOption = BitmapCacheOption.OnLoad;
                    bi.UriSource = new Uri( info.FullName );
                    bi.EndInit();
                    return bi;
                }
            }
            return null;
        }
        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            throw new NotImplementedException();
        }
    }
