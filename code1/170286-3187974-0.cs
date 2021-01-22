    public static void SetImage(Image image)
    {
        if (image == null)
        {
            throw new ArgumentNullException("image");
        }
        IDataObject data = new DataObject();
        data.SetData(DataFormats.Bitmap, true, image); // true means autoconvert
        Clipboard.SetDataObject(data, true); // true means copy
    }
