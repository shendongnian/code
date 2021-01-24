     public sealed partial class MainPage : Page
        {
    
            public MainPage() { this.InitializeComponent();
                inkCanvas.InkPresenter.InputDeviceTypes =
                  Windows.UI.Core.CoreInputDeviceTypes.Mouse |
                  Windows.UI.Core.CoreInputDeviceTypes.Touch |
                  Windows.UI.Core.CoreInputDeviceTypes.Pen;
            }
    
            private async void Button_Click(object sender, RoutedEventArgs e)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap();
                await rtb.RenderAsync(outputGrid);
    
                var pixelBuffer = await rtb.GetPixelsAsync();
                var pixels = pixelBuffer.ToArray();
                var displayInformation = DisplayInformation.GetForCurrentView();
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.FileTypeChoices.Add("Jpeg", new List<string>() { ".jpg" });
                savePicker.SuggestedFileName = "chart";
                StorageFile file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                        encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                             BitmapAlphaMode.Premultiplied,
                                             (uint)rtb.PixelWidth,
                                             (uint)rtb.PixelHeight,
                                             displayInformation.RawDpiX,
                                             displayInformation.RawDpiY,
                                             pixels);
                        await encoder.FlushAsync();
                    }
                }
            }
        }
