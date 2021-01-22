    imageList1.Images.Add( NEWIMAGE );
    ResXResourceWriter writer = new ResXResourceWriter("newresource.resx");
    writer.AddResource("imageList1.ImageStream",imageList1.ImageStream);
    writer.Generate();
    writer.Close();
    writer.Dispose();
