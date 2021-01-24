    public class ViewModel
    {
        public ObservableCollection<ImageThumbnail> ImageThumbnailList { get; } =
            new ObservableCollection<ImageThumbnail>();
        public void ThumbRemove(int index)
        {
            ImageThumbnailList.RemoveAt(index);
        }
        public void ThumbUpdate(BitmapImage image, int index)
        {
            ImageThumbnailList.RemoveAt(index);
            ImageThumbnailList.Insert(index, new ImageThumbnail()
            {
                ImageSource = image
            });
        }
        public async Task Thumb_save(int index)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            var filename_thumb = "xx"; // I dont have filename thumb that you should replace it to your code.
            var sampleFile_thumb_back = await storageFolder.CreateFileAsync(filename_thumb + index + ".jpg",
                CreationCollisionOption.ReplaceExisting);
            // we suggeste that use camelCase. Try to replace sampleFileThumbBack to sampleFile_thumb_back
            StorageFile file_thumb_back = sampleFile_thumb_back;
            IRandomAccessStream stream_thumb_back =
                await file_thumb_back.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (IOutputStream outputStream_thumb_back = stream_thumb_back.GetOutputStreamAt(0))
            {
                // for I dont have any ink that you should uncomment in your code
                //await ink1.InkPresenter.StrokeContainer.SaveAsync(outputStream_thumb_back);
                //await outputStream_thumb_back.FlushAsync();
            }
            stream_thumb_back.Dispose();
            var imgThumbnail_back =
                await file_thumb_back.GetThumbnailAsync(ThumbnailMode.PicturesView, 200,
                    ThumbnailOptions.ResizeThumbnail);
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.SetSource(imgThumbnail_back);
            ImageThumbnailList.Add(new ImageThumbnail()
            {
                ImageSource = bitmapImage
            });
        }
    }
