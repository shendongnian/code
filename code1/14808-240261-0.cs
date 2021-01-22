                string url = string.Format("http://www.foo.bar/page?name={0}&address={1}",
                    Uri.EscapeDataString("adlknad /?? lkm#"),
                    Uri.EscapeDataString(" qeio103 8182"));
                Console.WriteLine(url);
                Uri uri = new Uri(url);
                string[] options = uri.Query.Split('?','&');
                foreach (string option in options)
                {
                    string[] parts = option.Split('=');
                    if (parts.Length == 2)
                    {
                        Console.WriteLine("{0} = {1}",parts[0],
                            Uri.UnescapeDataString(parts[1]));
                    }
                }
