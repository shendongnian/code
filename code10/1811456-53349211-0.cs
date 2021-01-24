    private async Task PreProcessVideoToGetTextAsync(string videopath)
        {
            try
            {
                SoftwareBitmap softwareBitmap = null;
                StorageFile videofile = await StorageFile.GetFileFromPathAsync(videopath);
                var thumbnail = await GetThumbnailAsync(videofile);
                Windows.Storage.Streams.InMemoryRandomAccessStream randomAccessStream = new Windows.Storage.Streams.InMemoryRandomAccessStream();
                await Windows.Storage.Streams.RandomAccessStream.CopyAsync(thumbnail, randomAccessStream);
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(randomAccessStream);
                softwareBitmap = await decoder.GetSoftwareBitmapAsync();
                StorageFile outputFile = await ApplicationData.Current.LocalCacheFolder.CreateFileAsync(Path.GetFileNameWithoutExtension(videopath) + ".jpg");//save path for video thumbnail image in app cache folder
                using (Windows.Storage.Streams.IRandomAccessStream stream = await outputFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                   
                    BitmapEncoder encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.JpegEncoderId, stream);
                    encoder.SetSoftwareBitmap(softwareBitmap);
                    encoder.BitmapTransform.ScaledWidth = 128;//thumbnail width
                    encoder.BitmapTransform.ScaledHeight = 128;//thumbnail height
               
                    encoder.IsThumbnailGenerated = true;
                    try
                    {
                        await encoder.FlushAsync();
                        if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 || softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
                        {
                            softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                        }
                        var source = new Windows.UI.Xaml.Media.Imaging.SoftwareBitmapSource();
                        await source.SetBitmapAsync(softwareBitmap);
                        return;
                    }
                    catch (Exception err)
                    {
                        switch (err.HResult)
                        {
                            case unchecked((int)0x88982F81): //WINCODEC_ERR_UNSUPPORTEDOPERATION
                                                             // If the encoder does not support writing a thumbnail, then try again
                                                             // but disable thumbnail generation.
                                encoder.IsThumbnailGenerated = false;
                                break;
                            default:
                                throw err;
                        }
                    }
                    if (encoder.IsThumbnailGenerated == false)
                    {
                        await encoder.FlushAsync();
                    }
           
                }
                return;
            }
 
            catch (Exception)
            {
                return;
            }
            finally
            {
                GC.Collect();
            }
        
        }
    private async Task<Windows.Storage.Streams.IInputStream> GetThumbnailAsync(StorageFile file)
        {
            var mediaClip = await Windows.Media.Editing.MediaClip.CreateFromFileAsync(file);
            var mediaComposition = new Windows.Media.Editing.MediaComposition();
            mediaComposition.Clips.Add(mediaClip);
            return await mediaComposition.GetThumbnailAsync(
                TimeSpan.Zero, 0, 0, Windows.Media.Editing.VideoFramePrecision.NearestFrame);
        }
    }
