    #if __IOS__
        [Preserve(AllMembers = true)]
        [Register("MvxCachedImageView")]
    #elif __ANDROID__
        [Preserve(AllMembers = true)]
        [Register("ffimageloading.cross.MvxCachedImageView")]
    #endif
        /// <summary>
        /// MvxCachedImageView by Daniel Luberda
        /// </summary>
        public class MvxCachedImageView
    #if __IOS__
            : UIImageView, ICachedImageView, INotifyPropertyChanged
    #elif __ANDROID__
            : ImageViewAsync, ICachedImageView, INotifyPropertyChanged
    #endif
