    int picture = new Random().Next(1, 7);
    Dictionary<int, string> dictionary = new Dictionary<int, string>()
    {
        {1, "cherry.jpg"},
        {2, "bell.jpg"},
        {3, "lemon.jpg"},
        {4, "orange.jpg"},
        {5, "star.jpg"},
        {6, "skull.jpg"}
    };
    string res = "default.jpg";
    var pictures = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox2 };
    string path = System.IO.Path.Combine("C:\\Users\\seanb\\OneDrive\\Pictures\\" + dictionary.TryGetValue(picture, out res));
    pictures.ForEach(x => x.Image = Image.FromFile(path));
