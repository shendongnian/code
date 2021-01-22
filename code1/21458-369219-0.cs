    // Generate both tab-delimited and CSV strings.
    string tabbedText = //...
    string csvText = //...
    // Create the container object that will hold both versions of the data.
    var dataObject = new System.Windows.DataObject();
    // Add tab-delimited text to the container object as is.
    dataObject.SetText(tabbedText);
    // Convert the CSV text to a UTF-8 byte stream before adding it to the container object.
    var bytes = System.Text.Encoding.UTF8.GetBytes(csvText);
    var stream = new System.IO.MemoryStream(bytes);
    dataObject.SetData(System.Windows.DataFormats.CommaSeparatedValue, stream);
    // Copy the container object to the clipboard.
    System.Windows.Clipboard.SetDataObject(dataObject, true);
