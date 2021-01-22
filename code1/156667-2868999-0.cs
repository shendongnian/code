    private void image_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // Getting the Image instance which fired the event
        Image image = (Image)sender;
        string name = image.Name;
        int row = Grid.GetRow(image);
        int column = Grid.GetRow(image);
        // Do something with it
        ...
    }
