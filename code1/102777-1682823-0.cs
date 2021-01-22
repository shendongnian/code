    public class ClientComparer : IComparer<Client>
    {
        public int Compare(Client __c1, Client __c2)
        {
            string _name1 = GetName(__c1.Person);    
            string _name2 = GetName(__c2.Person);    
    
            if (_name1 == null)
            {
                if (_name2 == null)
                {
                    return 0;
                }
                return -1;
            }
            if (_name2 == null)
            {
                return 1;
            }
            return _name1.CompareTo(_name2);
        }
        private string GetName(Person person)
        {
            if (person is Person1)
            {
                return ((Person1)person).Type1Att;
            }
            else if (person is Person2)
            {
                return ((Person2)person).Type2Att;
            }
            else
            {
                throw new ArgumentException("Unhandled Person type.");
            }
        }
    }
