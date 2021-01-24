            public delegate void ChocolateAddedEventHander(Chocolate newChocolate);
            public class Model
            {
                //An Event which will be raised when you add new chocolate
                public event ChocolateAddedEventHander ChocolateAdded;
                //If at any point of program you need whole list of added chocolates
                public List<Chocolate> ChocolateList = new List<Chocolate>();
                public void AddChocolateInList (Chocolate chocolate)
                {
                    ChocolateList.Add(chocolate);
                    if (ChocolateAdded != null)
                        ChocolateAdded(chocolate);
                }
            }
