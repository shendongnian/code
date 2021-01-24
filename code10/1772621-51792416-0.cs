    public class CompareAttribut : IComparer<Attribut>
            {
                public int Compare(Attribut x, Attribut y)
                {
                    //SortParents
                    if (x.ATT_PARENT_ID == 0 && y.ATT_PARENT_ID == 0)
                    {
                        return x.ATT_LIBELLE.CompareTo(y.ATT_LIBELLE);
                    }
    
                    //It is a parent
                    if (x.ATT_PARENT_ID == 0)
                    {
                        if (x.ATT_ID == y.ATT_PARENT_ID) return -1;//Move Parent before its child
                        else return 1;//Push Parent down not belonging to child
                    }
    
                    if (x.ATT_PARENT_ID == y.ATT_ID) return 1; //it is a child belonging to the parent so move child under parent
    
                    return x.ATT_LIBELLE.CompareTo(y.ATT_LIBELLE);
                    
                }
            }
