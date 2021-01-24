            public class CardComparer : IComparer<Card>
            {
                public int Compare(Card x, Card y)
                {
                    int compResult = x.Suit.CompareTo(y.Suit);
                    if (compResult == 0)
                    {
                        compResult = x.Number.CompareTo(y.Number);
                    }
                    return compResult;
                }
            }
