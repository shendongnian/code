         public class Card : IEquatable<Card>
            {
                public string suit;
                public int number;
        
                public Card(string suit, int number)
                {
                    this.suit = suit;
                    this.number = number;
                }
        
                public bool Equals(Card other)
                {
                    if (ReferenceEquals(other, null))
                    {
                        return false;
                    }
                    return Equals(number, other.number);
                }
        
                public override int GetHashCode()
                {
                    return number.GetHashCode();
                }
        
            }
        
            public class FindCardPairs
            {
                public static List<IGrouping<Card, Card>> FindAllPairs(List<Card> input)
                {
                    List<IGrouping<Card,Card>> allPairs =  input.GroupBy(c => c).Where(g => g.Count() > 1).ToList();
                    return allPairs;
                }
            }
    
    [TestMethod]
            public void Card_Test_Equality()
            {
                var card1 = new Card(string.Empty, 2);
                var card2 = new Card("card2", 2);
    
                Assert.IsTrue(card1.Equals(card2));
            }
    
            [TestMethod]
            public void Test_FindAllPairs()
            {
                var cards = new List<Card>
                {
                    new Card(string.Empty, 2),
                    new Card("card2", 2)
                };
    
                List<IGrouping<Card, Card>> actual = FindCardPairs.FindAllPairs(cards);
                Assert.IsTrue(actual.Any());
                Assert.AreEqual(1, actual.Count());
    
            }
