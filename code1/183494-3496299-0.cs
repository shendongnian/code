    var copyClient = new Copy();
    copyClient .Credentials = credentials; // <-- Create Network Credentials
    var siteUrl = "http://....";
    var libraryName = "MyDocLibrary";
    var localFilePath = "...";
    var fileName = Path.GetFileName(localFilePath);
    var destinationUrl = string.Format("{0}/{1}/{2}", siteUrl, libraryName, fileName);
    var fileBytes = File.ReadAllBytes(localFilePath);
    var info = new[]{new FieldInformation
                            {
                                DisplayName = fileName,
                                Id = Guid.NewGuid(),
                                InternalName = fileName,
                                Type = FieldType.File,
                                Value = fileName
                            }};
    CopyResult[] results;
    copyClient.CopyIntoItems(destinationUrl, new[] { destinationUrl }, info, fileBytes, out results);
