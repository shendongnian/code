    var stringData = new StringBuilderEx();
    stringData.Append("Add lots of data");
    using (StreamWriter file = new System.IO.StreamWriter(localFilename))
    {
        stringData.ForEach((data) =>
        {
            file.Write(data);
        });
    }
