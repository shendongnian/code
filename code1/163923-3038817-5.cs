    public class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Shopping));
    
            var myShopping = new Shopping();
            myShopping.Discounts = new List<Discount>();
            myShopping.Discounts.Add(new Voucher() {MyVoucherName = "Foo", Amount = 6});
            myShopping.Discounts.Add(new Quantity() { MyQuantity = 100, Amount = 6 });
    
            StringBuilder xml = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(xml);
    
            xs.Serialize(xmlWriter, myShopping);
    
            Console.WriteLine("Serialized:");
            Console.WriteLine(xml);
    
            Console.WriteLine();
            Console.WriteLine("Deserialized:");
    
            TextReader tr = new StringReader(xml.ToString());
            var myNewShopping = (Shopping) xs.Deserialize(tr);
    
            if (myNewShopping.Discounts != null)
            {
                foreach (var discount in myNewShopping.Discounts)
                {
                    if (discount is Voucher)
                    {
                        var voucher = (Voucher) discount;
                        Console.WriteLine("Voucher - Amount={0}, Name={1}", voucher.Amount, voucher.MyVoucherName);
                    }
                    else if (discount is Quantity)
                    {
                        var quantity = (Quantity)discount;
                        Console.WriteLine("Quantity - Amount={0}, #={1}", quantity.Amount, quantity.MyQuantity);
                    }
                    else
                    {
                        Console.WriteLine("Discount - Amount={0}", discount.Amount);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Discounts found");
            }
    
            Console.ReadKey();
        }
