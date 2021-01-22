     class Program
            {
                static void Main(string[] args)
                {
                    XPathDocument saleResults = new XPathDocument( @"salesData.xml" );
                    XPathNavigator navigator = saleResults.CreateNavigator( );
                    XPathExpression selectExpression = navigator.Compile( "sales/item" );
                    XPathExpression sortExpr = navigator.Compile("@sTime");
                    selectExpression.AddSort(sortExpr, new DateTimeComparer());
                    XPathNodeIterator nodeIterator = navigator.Select( selectExpression );            
                    while ( nodeIterator.MoveNext( ) )
                    {
                        string checkMe = nodeIterator.Current.Value;
                    }
                }
                public class DateTimeComparer : IComparer
                {
                    public int Compare(object x, object y)
                    {
                        DateTime dt1 = DateTime.Parse( x.ToString( ) );
                        DateTime dt2 = DateTime.Parse( y.ToString( ) );
                        return dt1.CompareTo( dt2 );
                    }
                }
            }
