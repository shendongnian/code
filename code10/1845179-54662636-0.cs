     public static string RemoveIllegalFileNameChars(string input, string replacement = "")
        {
            if (input.Contains("?"))
            {
                input = input.Replace('?', char.Parse(" "));
            }
            if (input.Contains("&"))
            {
                input = input.Replace('&', char.Parse("-"));
            }
            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new     string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            // check for non asccii characters
            byte[] bytes = Encoding.ASCII.GetBytes(input);
            char[] chars = Encoding.ASCII.GetChars(bytes);
            string line = new String(chars);
            line = line.Replace("?", "");
            //MessageBox.Show(line);
            return r.Replace(line, replacement);
        }
