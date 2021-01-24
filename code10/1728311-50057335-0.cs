    private async void Button_Click(object sender, RoutedEventArgs e)
    {
            //Creates an empty PDF document instance
            PdfDocument document = new PdfDocument();
            //Adding new page to the PDF document
            PdfPage page = document.Pages.Add();
            //Creates new PDF font
            PdfStandardFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            //Drawing text to the PDF document
            page.Graphics.DrawString("Hello world", font, PdfBrushes.Black, 10, 10);
            StorageFile storageFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"panda.jpg");
            using (var filestream = await storageFile.OpenAsync(FileAccessMode.Read))
            {
                Stream st = filestream.AsStream();
                PdfBitmap pdfImage = new PdfBitmap(st);
                page.Graphics.DrawImage(pdfImage,0,20,500,500);
            }
            MemoryStream stream = new MemoryStream();
            //Saves the PDF document to stream
            await document.SaveAsync(stream);
            //Close the document
            document.Close(true);
            //Save the stream as PDF document file in local machine
            Save(stream, "Result.pdf");
    }
    async void Save(Stream stream, string filename)
    {
        stream.Position = 0;
        StorageFile stFile;
        if (!(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons")))
        {
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.DefaultFileExtension = ".pdf";
            savePicker.SuggestedFileName = "Sample";
            savePicker.FileTypeChoices.Add("Adobe PDF Document", new List<string>() { ".pdf" });
            stFile = await savePicker.PickSaveFileAsync();
        }
        else
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            stFile = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
        }
        if (stFile != null)
        {
            Windows.Storage.Streams.IRandomAccessStream fileStream = await stFile.OpenAsync(FileAccessMode.ReadWrite);
            Stream st = fileStream.AsStreamForWrite();
            st.Write((stream as MemoryStream).ToArray(), 0, (int)stream.Length);
            st.Flush();
            st.Dispose();
            fileStream.Dispose();
        }
    }
