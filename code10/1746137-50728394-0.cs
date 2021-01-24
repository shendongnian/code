    fileStream.CopyTo(memoryStream);
    Console.WriteLine(memoryStream.Position);
    memoryStream.Position = 0;
    Console.WriteLine(memoryStream.Position);
    var response = await dbx.Files.UploadAsync(folder + "/" + filename, WriteMode.Overwrite.Instance, body: memoryStream);
    Console.WriteLine((response as FileMetadata).Size);
