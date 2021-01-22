    BitmapImage bi = new BitmapImage(new Uri(@"C:\SimpleImage.jpg"));
    Image image = new Image();
    image.Source = bi;
    InlineUIContainer container = new InlineUIContainer(image);            
    Paragraph paragraph = new Paragraph(container); 
    RichTextBoxOutput.Document.Blocks.Add(paragraph);
