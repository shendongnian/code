    var assembly = typeof(App).GetTypeInfo().Assembly;
    var ImagesFiles = new List<string>(); 
    foreach (var res in assembly.GetManifestResourceNames())
                {
                    if (res.Contains(".jpg"))
                    {
                        ImagesFiles.Add(res);
                    }
                }
