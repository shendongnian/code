      if (req.Content.IsMimeMultipartContent())
                        // parse query parameter
         {
                 var content = await req.Content.ReadAsMultipartAsync();
                 var test = content.Contents.ToList();
                 Dictionary<string, string> dic = new Dictionary<string, string>();
                  foreach (var item in test)
                  {
                       var value = await item.ReadAsStringAsync();
                        dic.Add(item.Headers.ContentDisposition.Name, value);
                        log.Info(value);
                        System.Console.WriteLine(value);
                  }
                  // Set name to query string or body data
                  foreach (var item in dic)
                   {
                      log.Info($"{item.Key}:{item.Value}");
                   }
