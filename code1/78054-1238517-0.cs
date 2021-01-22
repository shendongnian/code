      using (var br = new FileStream(cacheFilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 0x10000, FileOptions.SequentialScan))
      {
          byte[] buffer = new byte[br.Length];
          br.Read(buffer, 0, buffer.Length);
          using (var memoryStream = new MemoryStream(buffer))
          {
              while (memoryStream.Position < memoryStream.Length)
              {
                  var doc = DocumentData.Deserialize(memoryStream);
                  docData[doc.InternalId] = doc;
              }
          }
      }
