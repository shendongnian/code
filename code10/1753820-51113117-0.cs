    public class ImageRenderListener : IRenderListener
    {
        public List<System.Drawing.Image> Images = new List<System.Drawing.Image>();
        public void BeginTextBlock()
        { }
        public void EndTextBlock()
        { }
        public void RenderText(TextRenderInfo renderInfo)
        { }
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            PdfImageObject imageObject = renderInfo.GetImage();
            if (imageObject == null)
            {
                Console.WriteLine("Image {0} could not be read.", renderInfo.GetRef().Number);
            }
            else
            {
                Images.Add(imageObject.GetDrawingImage());
            }
        }
    }
