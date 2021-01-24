            static void Main(string[] args) {
                Super.SETUP super = new Super.SETUP() {
                    ITEMS = new Super.ITEMS() {
                        XY = new List<Super.XY>() {
                           new Super.XY() { L = new Super.L() { Cclass = "ABC"}}
                       }
                    }
                };
                using (var stream = new FileStream(Directory.GetCurrentDirectory() + "\\file.xml", FileMode.Create))
                {
                    XmlSerializer X = new XmlSerializer(typeof(Super.SETUP));
                    X.Serialize(stream, super);
                }
            }
