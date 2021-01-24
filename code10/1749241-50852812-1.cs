    using (StreamReader SourceReader = System.IO.File.OpenText(pathToFile))
                {
                    builder.HtmlBody = SourceReader.ReadToEnd();
                }
    
    string htmlBody = builder.HtmlBody.Replace("{", "{{").Replace("}","}}")
    string messagebody = string.Format(htmlBody,
                        //Not important
                        );
