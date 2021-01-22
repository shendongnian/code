      public class DateTimeComparer : IComparer<object>
        {       
            public int Compare(object x, object y)
            {
                if ( x is DateTime && y is DateTime )
                {
                    return Comparer<DateTime>.Default.Compare((DateTime) x, (DateTime) y);
                }
                else
                {
                    // handle the type mismatch
                }
            }     
        }
