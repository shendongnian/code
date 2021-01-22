    class Program {
        public class CartItem {
                public string sku { get; set; }
                public int qty {get;set;}
                public decimal DiscountApplied { get; set; }
                public CartItem(string sku,int qty,decimal DiscountApplied) {
                    this.sku=sku;
                    this.qty=qty;
                    this.DiscountApplied=DiscountApplied;
                }
            }
     public class DiscountItem{
       public string sku {get;set;}
       public decimal DiscountAmount {get; set;}
    }
    static List<CartItem> carts=new List<CartItem>(){
    new CartItem("Ham",2,0.0m ),
    new CartItem("Bacon",1,0.00m  ),
    new CartItem("Ham",1,0.00m ),
    new CartItem("Bacon",2 ,0.00m),
    new CartItem("Cheese",1,0.00m),
    new CartItem("Bacon" , 1 ,  0.00m  )};
    
    static  List<DiscountItem> discounts=new List<DiscountItem>() {
        new DiscountItem(){ sku="Ham", DiscountAmount=0.33m},
        new DiscountItem(){sku="Bacon",DiscountAmount=2.0m}};
    
    class cartsPlus
    {
        public CartItem Cart { get; set; }
        public int AppliedCount { get; set; }
    }
    public static void Main(string[] args){
        int num = (from ca in discounts
                   join cart in carts on ca.sku equals cart.sku
                   group cart by ca.sku into g
                   select new { Sku = g.Key, Num = g.Sum(x => x.qty) }).Min(x => x.Num);
    
        var cartsplus = carts.Select(x => new cartsPlus { Cart = x, AppliedCount = 0 }).ToList();
    
        discounts.SelectMany(x => Enumerable.Range(1, num).Select(y => x)).ToList().ForEach(x=>{cartsPlus c=cartsplus.
                First(z=> z.Cart.sku==x.sku&&z.AppliedCount<z.Cart.qty);c.AppliedCount++;c.Cart.DiscountApplied+=x.DiscountAmount;});
    
         foreach (CartItem c in carts)
           Console.WriteLine("{0}  {1}   {2}", c.sku,c.qty, c.DiscountApplied);
    }
     };
