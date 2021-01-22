    // Create image.
    Image image1 = Image.FromFile("c:\\Photo1.jpg");
    // Get a PropertyItem from image1. Because PropertyItem does not
    // have public constructor, you first need to get existing PropertyItem
    PropertyItem propItem = image1.GetPropertyItem(20624);
    // Change the ID of the PropertyItem.
    propItem.Id = 20625;
    // Set the new PropertyItem for image1.
    image1.SetPropertyItem(propItem);
    // Save the image.
    image1.Save("c:\\Photo1.jpg", ImageFormat.Jpg);
