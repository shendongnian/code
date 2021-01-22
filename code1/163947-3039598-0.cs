    imageList1.Images.Add( NEWIMAGE );
    ResXResourceWriter writer = new ResXResourceWriter("newresource.resx");
    writer.AddResource("val",imageList1.ImageStream);
    writer.Generate();
    writer.Close();
    writer.Dispose();
