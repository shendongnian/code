    public static Image GetImage() {
        IDataObject dataObject = Clipboard.GetDataObject();
        if (dataObject != null) {
            return dataObject.GetData(DataFormats.Bitmap, true) as Image;
        }
        return null;
    }
