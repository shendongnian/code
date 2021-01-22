    public class PhotoDetailsViewModel
        : PropertyChangedNotifierBase<PhotoDetailsViewModel>
    {
        public bool IsLoading
        {
            get { return GetValue(x => x.IsLoading); }
            set { SetPropertyValue(x => x.IsLoading, value); }
        }
        public string PendingOperation
        {
            get { return GetValue(x => x.PendingOperation); }
            set { SetPropertyValue(x => x.PendingOperation, value); }
        }
        public PhotoViewModel Photo
        {
            get { return GetValue(x => x.Photo); }
            set { SetPropertyValue(x => x.Photo, value); }
        }
    }
