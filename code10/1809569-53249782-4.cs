    public class ManilleComparer : IComparer<Kaart>
                {
                    private List<Kleur> KleurRank = new List<Kleur>() { Kleur.Ruiten , Kleur.Klaveren, Kleur.Schoppen, Kleur.Harten };
                    private List<Nummer> NummerRank = new List<Nummer>() { Nummer.Twee, Nummer.Drie, Nummer.Vier, Nummer.Vier, Nummer.Zes, Nummer.Zeven,  Nummer.Acht, Nummer.Negen, Nummer.Boer, Nummer.Dame, Nummer.Heer, Nummer.Aas, Nummer.Tien };
    
                    public int Compare(Kaart x, Kaart y)
                    {
                        int compareTo = KleurRank.IndexOf(x.Kleur).CompareTo(KleurRank.IndexOf(y.Kleur)); //check symbols against each other
                        
                        if (compareTo == 0) // if value is 0 they have the same symbol
                        {
                            compareTo = NummerRank.IndexOf(x.Nummer).CompareTo(NummerRank.IndexOf(y.Nummer));  
                        }
    
                        return compareTo; 
                    }
                }
