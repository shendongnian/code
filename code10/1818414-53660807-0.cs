                string content = streamReader.ReadToEnd();
                var stringList = content.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                Dictionary<string, List<string>> file = new Dictionary<string, List<string>>();
                for (var i = 0; i < stringList.Count(); i++)
                {
                    string line = stringList[i];
                    string path = line.Replace("\r\n", "");
                    path = path.Replace(" ", "");
                    path = path.TrimEnd(':');
                    if (File.Exists(path))
                    {
                        file[path] = file.ContainsKey(path) ? file[path] : new List<string>();
                        for (var j = i + 1; j < stringList.Count(); j++)
                        {
                            string line2 = stringList[j];
                            string path2 = line2.Replace("\r\n", "");
                            path2 = path2.Replace(" ", "");
                            path2 = path2.TrimEnd(':');
                            if (File.Exists(path2))
                            {
                                i = j - 1;
                                break;
                            }
                            else
                            {
                                file[path].Add(listValue);
                            }
                        }
                    }
                }
