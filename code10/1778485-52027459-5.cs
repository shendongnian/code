    public class OpenRecordUI
    {
        private List<IUIBaseProperties> UIElements;
    
        public OpenRecordUI()
        {
            UIElements = new List<IUIBaseProperties>();
            UIElements.Add(new EasyRawImage(Resources.Load("Images/" + Data.local_photo_name), new Vector2(50, 50), v.GetActualPixelSizes().size.x, v.GetActualPixelSizes().size.y));
            var test = UIElements[0].SetImageDimensions();
        }
    }
