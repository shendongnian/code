           public async Task<List<string>> DoRandom(FileLists fl, StorageFolder folder)
        {
            FileLists retLists = new FileLists();
            List<string> encodingList = new List<string>();
            foreach (UploadedFile i in fl)
            {
                // read stream from storagefile
                Stream s = await i.originFile.OpenStreamForReadAsync(); 
                // streamreader from stream
                StreamReader sr = new StreamReader(s, Encoding.ASCII);
                await i.setOutFile(folder) ; // wait until setOutFile ends
                if (sr.CurrentEncoding == Encoding.ASCII)
                {
                    encodingList.Add("ASCII   " + i.outputName);
                }
                string str = await sr.ReadToEndAsync();
                StringBuilder stringBuilder = new StringBuilder(str);
                if (Option1)
                {
                    doOption1(stringBuilder);
                }
                await FileIO.WriteTextAsync(i.outputFile, stringBuilder.ToString());
                if (Option1);
            };
            return encodingList;
        }
