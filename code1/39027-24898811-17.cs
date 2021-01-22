    private void SaveFileAs(Object sender, RoutedEventArgs e)
        {
            SaveFileDialog SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            if (SaveFileDialog.ShowDialog() == true)
            {
                try
                {
                    if (SaveFileDialog.FileName != null)
                    {
                        String DestinationPath = SaveFileDialog.FileName;
                        FileStream DestinationFileStream = new FileStream(DestinationPath, FileMode.Create, FileAccess.Write, FileShare.Write);
                        switch (SaveFileDialog.FilterIndex)
                        {   
                            case 1:
                                PdfDocument PdfDocument = new PdfDocument();
                                PdfPage PdfPage = new PdfPage();
                                PdfDocument.Pages.Add(PdfPage);
                                XImage Image = XImage.FromBitmapSource(BitmapSource);
                                XGraphics XGraphic = XGraphics.FromPdfPage(PdfDocument.Pages[0]);
                                Double VerticalMargin = 20;
                                Double HorizontalMargin = 20;
                                Double Ratio = BitmapSource.Height / BitmapSource.Width;
                                Double ImageWidth = PdfPage.Width - 2 * VerticalMargin;
                                Double ImageHeight = Ratio * (PdfPage.Width - 2 * HorizontalMargin);
                                XGraphic.DrawImage(Image, VerticalMargin, HorizontalMargin, ImageWidth, ImageHeight);
                                PdfDocument.Save(DestinationFileStream);
                                PdfDocument.Close();
                                DestinationFileStream.Close();
                                break;
                        }
                    }
                }
                catch (Exception Exception)
                {
                    MessageBox.Show("Error: Could not write file to disk. Original error: ", Exception.Message, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
