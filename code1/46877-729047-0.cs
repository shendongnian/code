        static void Main() {
            Test("<abc><def/></abc>");
            Test("<abc><def/><abc>");
        }
        static void Test(string xml) {
            using (XmlReader xr = XmlReader.Create(
                    new StringReader(xml))) {
                try {
                    while (xr.Read()) { }
                    Console.WriteLine("Pass");
                } catch (Exception ex) {
                    Console.WriteLine("Fail: " + ex.Message);
                }
            }
        }
