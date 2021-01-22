        void ParseLine(string charClass, string line) {
            // your code to parse line here...
            Console.WriteLine("{0} : {1}", charClass, line);
        }
        void ParseFile(string fileName) {
            string currentClass = "";
            using (StringReader sr = new StringReader(fileName)) {
                string line = sr.ReadLine();
                if (line[0] == '@') {
                    string embeddedFile = line.Substring(1);
                    ParseFile(embeddedFile);
                }
                else if (line[0] == '[') {
                    currentClass = line.Substring(2, line.Length - 2);
                }
                else ParseLine(currentClass, line);
            }
        }
