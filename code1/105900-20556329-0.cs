    string fileName = "c:/SomeImage.jpg";
    // Retrieve the Image
    System.Drawing.Image originalImage = System.Drawing.Image.FromFile(fileName);
    // Get the list of existing PropertyItems. i.e. the metadata
    PropertyItem[] properties = originalImage.PropertyItems;
    // Create a bitmap image to assign attributes and do whatever else..
    Bitmap bmpImage = new Bitmap((Bitmap)originalImage);
    // Don't need this anymore
    originalImage.Dispose();
    // Get / setup a PropertyItem
    PropertyItem item = properties[0]; // We have to copy an existing one since no constructor exists
    // This will assign "Joe Doe" to the "Authors" metadata field
    string sTmp = "Joe DoeX"; // The X will be replaced with a null.  String must be null terminated.
    var itemData = System.Text.Encoding.UTF8.GetBytes(sTmp);
    itemData[itemData.Length - 1] = 0;// Strings must be null terminated or they will run together
    item.Type = 2; //String (ASCII)
    item.Id = 315; // Author(s), 315 is mapped to the "Authors" field
    item.Len = itemData.Length; // Number of items in the byte array
    item.Value = itemData; // The byte array
    bmpImage.SetPropertyItem(item); // Assign / add to the bitmap
    // This will assign "MyApplication" to the "Program Name" field
    sTmp = "MyApplicationX";
    itemData = System.Text.Encoding.UTF8.GetBytes(sTmp);
    itemData[itemData.Length - 1] = 0; // Strings must be null terminated or they will run together
    item.Type = 2; //String (ASCII)
    item.Id = 305; // Program Name, 305 is mapped to the "Program Name" field
    item.Len = itemData.Length;
    item.Value = itemData;
    bmpImage.SetPropertyItem(item);
           
    // Save the image
    bmpImage.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
    //Clean up
    bmpImage.Dispose();
