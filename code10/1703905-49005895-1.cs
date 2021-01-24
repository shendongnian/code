      if (req.Content.IsMimeMultipartContent())
         {
              var content = await req.Content.ReadAsMultipartAsync();
              var test = content.Contents.ToList();
              Dictionary<string, string> dic = new Dictionary<string, string>();
              foreach (var item in test)
              {
                  var value = await item.ReadAsStringAsync();
                  dic.Add(item.Headers.ContentDisposition.Name, value);
                  log.Info(value);
              }
              foreach (var item in dic)
              {
                 log.Info($"{item.Key}:{item.Value}");
              }
         }
