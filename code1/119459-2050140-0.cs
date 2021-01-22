        static void Main(string[] args)
        {
            Console.WriteLine(Adjust("3123~101", @"3123|X:directory\Path\Directory|Pre0{0442-0500}.txt"));
            Console.WriteLine(Adjust("3123~101", @"3123|X:directory\Path\Directory|0{0442-0500}.txt"));
        }
        private static string Adjust(string name, string file)
        {
            Regex nameParse = new Regex(@"\d*~(?<value>\d*)");
            Regex fileParse = new Regex(@"\d*\|(?<drive>[A-Za-z]):(?<path>[^\|]*)\|(?<prefix>[^{]*){(?<code>\d*)");
            Match nameMatch = nameParse.Match(name);
            Match fileMatch = fileParse.Match(file);
            int value = Convert.ToInt32(nameMatch.Groups["value"].Value);
            int code = Convert.ToInt32(fileMatch.Groups["code"].Value);
            code = code + value - 1;
            string drive = fileMatch.Groups["drive"].Value;
            string path = fileMatch.Groups["path"].Value;
            string prefix = fileMatch.Groups["prefix"].Value;
            string result = string.Format(@"{0}:\{1}\{2}{3:0000}.txt",
                drive, 
                path,
                prefix, 
                code);
            return result;
        }
