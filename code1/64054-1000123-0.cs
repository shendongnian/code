        static void Main(string[] args) {
            Dictionary<string, string> options = new Dictionary<string, string>();
            foreach (string arg in args)
            {
                string[] pieces = arg.Split('=');
                options[pieces[0]] = pieces.Length > 1 ? pieces[1] : "";
            }
            Console.WriteLine(options["Name"]); // access by key
            // get just the values
            string[] vals = new string[options.Count];
            options.Values.CopyTo(vals, 0);
        }
