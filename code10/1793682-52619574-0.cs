    try {
                FileOpenPicker openPicker = new FileOpenPicker {
                    ViewMode = PickerViewMode.Thumbnail,
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    FileTypeFilter = { ".jpg", ".jpeg", ".png" }
                };
                StorageFile file = await openPicker.PickSingleFileAsync();
                if (file != null) {
                    using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read)) {
                        var reader = new Windows.Storage.Streams.DataReader(fileStream.GetInputStreamAt(0));
                        var LoadReader = await reader.LoadAsync((uint)fileStream.Size);
                        byte[] pixels = new byte[fileStream.Size];
                        reader.ReadBytes(pixels);
                    }
                }
            } catch (Exception ex) {
            }
