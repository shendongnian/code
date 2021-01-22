        public class Person : IComparable<Person>
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
        
                public int CompareTo(Person obj)
            {
            return this.parentID.CompareTo(obj.parentID);
            //OR 
            //if (this.parentID > obj.parentID)
            //{
            //    return 1;
            //}
            //else if (this.parentID < obj.parentID)
            //{
            //    return -1;
            //}
            //return 0;
            }        
                #endregion
            }
