    namespace ShoppingList {
        class ShoppingList {
            static void Main(string[] args) {
                Grocery myGrocery = new Grocery("Bread", 1);
                FreshProduce myFreshProduce = new FreshProduce("Orange", 1);
                List<Product> myShoppingList = new List<Product>();
                myShoppingList.Add(myGrocery);
                myShoppingList.Add(myFreshProduce);
                PrintValues(myShoppingList, "\t");
            }
            // instead of IEnumerable, you should use IEnumerable<Product> for better type checking
            public static void PrintValues(IEnumerable<Product> myList, string mySeparator) {
                // string.Join does exactly what you are trying to do using a loop
                Console.WriteLine(string.Join(mySeparator, myList));
            }
            public abstract class Product {
                protected string Name;
                protected int Quantity;
                public override string ToString() {
                    return $"Name = {Name}, Quantity = {Quantity}";
                }
            }
            public class Grocery : Product {
                public Grocery(string groceryName, int groceryQuantity) {
                    Name = groceryName;
                    Quantity = groceryQuantity;
                }
            }
            public class FreshProduce : Product {
                public FreshProduce(string freshProduceName, int freshProduceQuantity) {
                    Name = freshProduceName;
                    Quantity = freshProduceQuantity;
                }
            }
        }
    }
