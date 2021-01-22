     string name = "Whatever name with valid/invalid chars";
     char[] invalid = System.IO.Path.GetInvalidFileNameChars();
     string validFileName = string.Join(string.Empty,
                                string.Format("{0}.{1:G}.kmz", name, DateTime.Now)
                                .ToCharArray().Select(o => o.In(invalid) ? '_' : o));
