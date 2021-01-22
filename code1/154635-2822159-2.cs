    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BasketOfFruits;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Basket myBasket = new Basket();
                myBasket.Fruit = new string[] { "Apple", "Orange", "Grapes" };
    
                XmlSerializer xs = new XmlSerializer(typeof(Basket));            
                XmlSerializerNamespaces emptyNamespace = new XmlSerializerNamespaces();
                emptyNamespace.Add(String.Empty, String.Empty);
                
                StringBuilder output = new StringBuilder();
    
                XmlWriter writer = XmlWriter.Create(output, 
                    new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true });
                xs.Serialize(writer, myBasket, emptyNamespace);
    
                Console.WriteLine(output.ToString());
    
                // pause program execution to review results...
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }
