     interface ITarget
        {
          List<string> GetProducts();
        }
        
        
        public class VendorAdaptee
        {
           public List<string> GetListOfProducts()
           {
              List<string> products = new List<string>();
              products.Add("Gaming Consoles");
              products.Add("Television");
              products.Add("Books");
              products.Add("Musical Instruments");
              return products;
           }
        }
        
        
        class VendorAdapter:ITarget
        {
           public List<string> GetProducts()
           {
              VendorAdaptee adaptee = new VendorAdaptee();
              return adaptee.GetListOfProducts();
           }
        }
        
        
        class ShoppingPortalClient
        {
           static void Main(string[] args)
           {
              ITarget adapter = new  VendorAdapter();
              foreach (string product in adapter.GetProducts())
              {
                Console.WriteLine(product);
              }
              Console.ReadLine();
           }
        }
