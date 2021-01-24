    abstract class Narys: IComparable
    {
        ...
        public int CompareTo(object obj) 
        {
            if (obj == null) return 1;
        
            Nardys otherMember = obj as Nardys;
            if (otherMember != null) 
            {
                // Check to see if last name is the same
                if (this.Pavarde.CompareTo(otherMember.Pavarde)==0)
                {
                    // Compare first names 
                    return this.Vardas.CompareTo(otherMember.Vardas);
                }
                else
                {
                    // Compare last names
                    return this.Pavarde.CompareTo(otherMemder.Pavarde);
                }  
            }
            else
            {
                throw new ArgumentException("Object is not a Nardys");
            }
        }
    }
