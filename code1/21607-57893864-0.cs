        public string GetSafeFilename(string filename)
        {
            string res = string.Join("!", filename.Split(Path.GetInvalidFileNameChars()));
            while (res.IndexOf("!!") >= 0)
                res = res.Replace("!!", "!");
            return res;
        }
