        public static BitmapSource RenderChartAsImage(FrameworkElement chart)
        {
            RenderTargetBitmap image = new RenderTargetBitmap((int)chart.ActualWidth, (int)chart.ActualHeight,
                                                                96, 96, PixelFormats.Pbgra32);
            image.Render(chart);
            return image;
        }
		public static void SaveChartImage(FrameworkElement chart)
		{
            System.Windows.Media.Imaging.BitmapSource bitmap = RenderChartAsImage(chart);
            Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();
            saveDialog.FileName += "mychart";
            saveDialog.DefaultExt = ".png";
            saveDialog.Filter = "Image (*.png)|*.png";
            if (saveDialog.ShowDialog() == true)
            {
                using (FileStream stream = File.Create(saveDialog.FileName))
                {
                    System.Windows.Media.Imaging.PngBitmapEncoder encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
                    encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bitmap));
                    encoder.Save(stream);
                }
            }
		}
