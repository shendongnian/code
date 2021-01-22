            private void SaveToImage(Word.InlineShape picShape, string filePath)
        {
            picShape.Select();
            theApp.Selection.CopyAsPicture();
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(typeof(Bitmap)))
            {
                Bitmap image = (Bitmap)data.GetData(typeof(Bitmap));
                image.Save(filePath);
            }
        }
