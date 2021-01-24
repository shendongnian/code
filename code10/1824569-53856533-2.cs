    public static Image GetImage() {
        var dataObject = Clipboard.GetDataObject();
        if (dataObject != null) {
            return dataObject.GetData(DataFormats.Bitmap, true) as Image;
        }
        return null;
    }
