    /// <summary>
    /// Set object on the clipboard, together with its string representation.
    /// </summary>
    /// <param name="myObject">object to be stored on the clipboard.</param>
    public static void PutOnClipboardWithTextVersion<T>(T myObject) where T : class
    {
        DataObject data = new DataObject();
        data.SetData(myObject); // identical to data.SetData(typeof(T), myObject);
        data.SetText(myObject.ToString());
        // The second arg makes the data stay available after the program closes.
        Clipboard.SetDataObject(data, true);
    }
