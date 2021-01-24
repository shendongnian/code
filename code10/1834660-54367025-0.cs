    public class CatSorter : Comparer<Achat>
    {
        public override int Compare(Achat x, Achat y)
        {
            int result = x.CatArt.CompareTo(y.CatArt);
            if (result != 0)
            {
                return result;
            }
            else
            {
                result = x.CatOrder.CompareTo(y.CatOrder);
                if (result != 0)
                {
                    return result;
                }
                else
                {
                    return x.NomArt.CompareTo(y.NomArt);
                }
            }
        }
    }
