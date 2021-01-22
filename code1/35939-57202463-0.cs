    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument xml = XDocument.Parse(@"
            <root>
              <child id='1'/>
              <child id='2'>
                <subChild id='3'>
                    <extChild id='5' />
                    <extChild id='6' />
                </subChild>
                <subChild id='4'>
                    <extChild id='7' />
                </subChild>
              </child>
            </root>");
      
            xml.Descendants().Where(p => p.Name.LocalName == "extChild")
                             .ToList()
                             .ForEach(e => Console.WriteLine(e));
    
            Console.ReadLine();
        }
    }
