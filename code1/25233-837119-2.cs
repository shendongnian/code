    public UIElement Icon
    {
        get
        {
            if (TriggerProperty == "2")
            {
                Rectange rect = new Rectangle();
                rect.Fill = Brushes.Red;
                return rect;
            }
    
            else
            {
                Image img = new Image();
                ImageSourceConverter s = new ImageSourceConverter();
                img.Source = (ImageSource)s.ConvertFromString("MyImage.png");
                return img;
            }
        }
    }
