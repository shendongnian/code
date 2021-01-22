    foreach (string fileString in collection.AllKeys) {
                        HttpPostedFile _file = collection[fileString];
                        if (_file.ContentLength > 0)
                            
                            items.Add(new Attachment()
                            {
                                ContentType = _file.ContentType,
                                Name = _file.FileName.LastIndexOf('\\') > 0 ? _file.FileName.Substring(_file.FileName.LastIndexOf('\\') + 1) : _file.FileName,
                                Size = _file.ContentLength / 1024,
                                FileContent = new Binary(new BinaryReader(_file.InputStream).ReadBytes((int)_file.InputStream.Length))
                            });
    
                        else
                            continue;
                    }
