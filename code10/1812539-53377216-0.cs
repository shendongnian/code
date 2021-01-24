    Dictionary<int, Image> dictionary = new Dictionary<int, Image>()
    {
        {1,  Image.FromFile("C:\\Users\\seanb\\OneDrive\\Pictures\\cherry.jpg"},
        {2,  Image.FromFile("C:\\Users\\seanb\\OneDrive\\Pictures\\bell.jpg"},
    };
    dictionary.TryGetValue(picture, out value);
    if (value != null)
    {
        this.element.Image = value;
    }
