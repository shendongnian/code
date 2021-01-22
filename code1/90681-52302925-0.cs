        [XmlStylesheet("USED-FILE.xsl")]
        public class Xxx
        {
            // etc
        }
        Xxx x = new Xxx();
        XmlSerializer s = new XmlSerializer(typeof(Xxx));
        using (var  tw = File.CreateText(@"c:\Temp\test.xml"))
        using (var xw = XmlWriter.Create(tw))
        {
            s.SerializeWithStyle(xw, x);    // only line here that needs to change. 
                                            // rest is standard biolerplate.
        }
