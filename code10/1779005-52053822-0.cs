           public async Task<List<string>> DoRandom(FileLists fl, StorageFolder folder, StorageFile another_file, int k)
       {
            FileLists retLists = new FileLists();
            List<string> encodingList = new List<string>();
            if (Option1)
            {
                foreach (UploadedFile i in fl)
                {
                    await i.setOutFile(folder); // wait until setOutFile ends
                    // read stream from storagefile
                    using (Stream s = await i.originFile.OpenStreamForReadAsync())
                    {
                        // streamreader from stream
                        using (StreamReader sr = new StreamReader(s))
                        {
                            string str = await sr.ReadToEndAsync();
                            StringBuilder stringBuilder = new StringBuilder(str);
                            List<string> ans = doOption1(stringBuilder, k);
                            StringBuilder ret = new StringBuilder();
                            foreach (var j in ans)
                            {
                                ret.Append(j); //<--- append all string
                            }
                            await FileIO.WriteTextAsync(i.outputFile, ret.ToString()); // <-- write it at one time
                        }
                    }
                }
            
  
