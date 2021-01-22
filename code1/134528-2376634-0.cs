    public class PersonComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int retval = x.FirstName.CompareTo(y.FirstName);
    
                    if (retval != 0)
                    {
                        return retval;
                    }
                    else
                    {
                        return x.Rank.CompareTo(y.Rank);
                    }
                }
            }
        }
    }
