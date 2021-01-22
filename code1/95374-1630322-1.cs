        XDocument d = XDocument.Parse(@"<?xml version='1.0' encoding='utf-8' ?>
            <Customers dId='wqwx' dTime='10-9-09 11:23'>
                <Customer id='1'>      
                    <Orders>        
                        <Order number='22' status='ok'/>      
                    </Orders>   
                </Customer> 
            </Customers>");
        var cu = d.Root.Elements().Where(n => n.Name == "Customer");
        var c = from cc in cu
                select new
                {
                    dId = cc.Document.Root.Attribute("dId").Value,
                    dTime = cc.Document.Root.Attribute("dTime").Value,
                    ID = cc.Attribute("id").Value,
                    number = cc.Element("Orders").Element("Order").Attribute("number").Value
                };
        foreach (var v in c)
        {
            Console.WriteLine("dId \t\t= {0}", v.dId);
            Console.WriteLine("dTime \t\t= {0}", v.dTime);
            Console.WriteLine("CustomerID \t= {0}", v.ID);
            Console.WriteLine("OrderCount \t= {0}", v.number);
        }
