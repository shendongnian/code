    // At this point the new bitmap has no MimeType
    // Need to output to memory stream
    using (var m = new MemoryStream())
    {
           dst.Save(m, format);
           var img = Image.FromStream(m);
                           
           //TEST
           img.Save("C:\\test.jpg");
           var bytes = PhotoEditor.ConvertImageToByteArray(img);
                            
                            
           return img;
     }
