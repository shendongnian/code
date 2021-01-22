    <Rectangle.Fill>
        <ImageBrush ImageSource="{Binding Cover}" />
    </Rectangle.Fill>
    
    private ImageSource _cover;
    public ImageSource Cover
    {
        get
        {
            if (_cover == null)
            {
                _cover = LoadImage();
            }
            return _cover;
        }
    }
