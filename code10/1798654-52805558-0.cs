    var filename = "The.Red.The.Blue.The.Green.Notification.Paper.R23B22.docx";
    var result = filename.Substring(filename.LastIndexOf('.')-6);
    int index = result.IndexOf(".",StringComparison.InvariantCulture);
    if (index > 0)
    {
       result = result.Substring(0, index); // result = R23B22
    }
     
