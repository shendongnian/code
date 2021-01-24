    if (System.IO.File.Exists(_uploadFile))
                {
                    File body = new File();
                    body.Title = System.IO.Path.GetFileName(_uploadFile);
                    body.Description = "File uploaded by Diamto Drive Sample";
                    body.MimeType = GetMimeType(_uploadFile);
                    body.Parents = new List() { new ParentReference() { Id = _parent } };
    
                    // File's content.
                    byte[] byteArray = System.IO.File.ReadAllBytes(_uploadFile);
                    System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
                    try
                    {
                        FilesResource.InsertMediaUpload request = _service.Files.Insert(body, stream, GetMimeType(_uploadFile));
                        request.Upload();
                        return request.ResponseBody;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("An error occurred: " + e.Message);
                        return null;
                    }
                }
                else {
                    Console.WriteLine("File does not exist: " + _uploadFile);
                    return null;
                }
 
