            var info = "ZipEntry: testfile.txt\n   Version Made By: 45\n Needed to extract: 45\n         File type: binary\n       Compression: Deflate\n        Compressed: 0x35556371\n      Uncompressed: 0x1D626FBDB\n      ...";
            var values = new Dictionary<string, string>();
            IList<string> split = info.Split(new char[] { ':', '\n' }).Select(x => x.Trim()).ToList();
            if (split.Count > 0)
            {
                for (int i = 1; i < split.Count; i++)
                {
                    if (i % 2 != 0)
                        values.Add(split[i - 1], split[i]);
                    else if (i == split.Count - 1)
                        values.Add(split[i], "");
                }
            }
            string compression = values["Compression"];
