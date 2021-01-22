    class Program {
        static void Main(string[] args) {
            String line = String.Empty;
            String someText = "\nSome Text\n";
            StringReader stringReader = new StringReader(someText);
            while ((line = stringReader.ReadLine()) != null) {
                if (!String.IsNullOrEmpty(line)) {
                    // do something with the line that has content;
                }
            }
        }
    }
