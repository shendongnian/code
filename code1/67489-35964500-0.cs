    List<Image> list = new List<Image>();
    foreach (string imageFile in images)
    {
        list.Add(Image.FromFile(imageFile)); 
    }
    imageList.Images.AddRange(list.ToArray());
