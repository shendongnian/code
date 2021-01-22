        public class Person : IComparable
            {
                public int id, parentID;
                public string name;
        
                public Person(int id, string name, int parentID)
                {
                    this.id = id;
                    this.name = name;
                    this.parentID = parentID;
                }
        
                #region IComparable Members
        
                public int CompareTo(object obj)
                {
    
                    return this.parentID.CompareTo(((Person)obj).parentID);
    
                //OR 
                //if (this.parentID > ((Person)obj).parentID)
                //{
                //    return 1;
                //}
                //else if (this.parentID < ((Person)obj).parentID)
                //{
                //    return -1;
                //}
    
                //return 0;            
                }
        
                #endregion
            }
