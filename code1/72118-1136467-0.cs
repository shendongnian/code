    class Program
        {
            //I just copied your stuff to Test.xml
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load("Test.xml");
                var verbs=new Dictionary<string,string>();
                //Add the values to replace ehre
                verbs.Add("@@value3@@", "mango");
                verbs.Add("@@value1@@", "potato");
                ReplaceStuff(verbs, doc.Root.Elements());
                doc.Save("Test2.xml");
            }
    
            //A simple replace class
            static void ReplaceStuff(Dictionary<string,string> verbs,IEnumerable<XElement> elements)
            {
                foreach (var e in elements)
                {
                    if (e.Elements().Count() > 0)
                        ReplaceStuff(verbs, e.Elements() );
                    else
                    {
                        if (verbs.ContainsKey(e.Value.Trim()))
                            e.Value = verbs[e.Value];
                    }
                }
            }
        }
