    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
    {
        static void Main(string[] args)
        {
            List<Attribut> sortList = new List<Attribut>();
            sortList.Add(new Attribut() { ATT_ID = 356, ATT_LIBELLE = "Avis client requis", ATT_PARENT_ID = 0 });
            sortList.Add(new Attribut() { ATT_ID = 357, ATT_LIBELLE = "Nom du destinataire client", ATT_PARENT_ID = 356 });
            sortList.Add(new Attribut() { ATT_ID = 358, ATT_LIBELLE = "Date d'envoi au client pour avis", ATT_PARENT_ID = 356 });
            sortList.Add(new Attribut() { ATT_ID = 366, ATT_LIBELLE = "CNPE ?", ATT_PARENT_ID = 0 });
            sortList.Add(new Attribut() { ATT_ID = 367, ATT_LIBELLE = "Palier", ATT_PARENT_ID = 366 });
            sortList.Add(new Attribut() { ATT_ID = 368, ATT_LIBELLE = "Tranche", ATT_PARENT_ID = 366 });
            sortList.Add(new Attribut() { ATT_ID = 369, ATT_LIBELLE = "Site", ATT_PARENT_ID = 366 });
            sortList.Add(new Attribut() { ATT_ID = 370, ATT_LIBELLE = "Materiel", ATT_PARENT_ID = 366 });
            sortList.Add(new Attribut() { ATT_ID = 371, ATT_LIBELLE = "Machine", ATT_PARENT_ID = 366 });
            sortList.Add(new Attribut() { ATT_ID = 372, ATT_LIBELLE = "Affaire parent", ATT_PARENT_ID = 366 });
            
            
            Random rand = new Random(14); 
            for(int i = 0; i < 30;i++)
            {
                int ra = rand.Next(10);
                Attribut move = sortList[ra];
                sortList.RemoveAt(ra);
                sortList.Add(move);
            }
            sortList.Sort(new CompareAttribut(sortList));
            foreach (Attribut oneAtt in sortList)
            {
                Console.WriteLine(oneAtt.ATT_ID + " " + oneAtt.ATT_LIBELLE + " " + oneAtt.ATT_PARENT_ID);
            }
        }
        public class CompareAttribut : IComparer<Attribut>
        {
            private class AttributHelper:Attribut, IComparable<AttributHelper>
            {
                public string PARENT_LIBELLE { get; set; }
                public int CompareTo(AttributHelper other)
                {
                    return ATT_ID.CompareTo(other.ATT_ID);
                }
            }
            private List<AttributHelper> helpers;
            public CompareAttribut(List<Attribut> StartList)
            {
                helpers = StartList.Select(a => new AttributHelper()
                {
                    ATT_ID = a.ATT_ID,
                    ATT_PARENT_ID = a.ATT_PARENT_ID,
                    ATT_LIBELLE = a.ATT_LIBELLE,
                    
                }).OrderBy(a =>a.ATT_ID).ToList();
                foreach (AttributHelper ah in helpers)
                {
                    if (ah.ATT_PARENT_ID > 0) ah.PARENT_LIBELLE = StartList.Single(p => p.ATT_ID == ah.ATT_PARENT_ID).ATT_LIBELLE;
                    else ah.PARENT_LIBELLE = ah.ATT_LIBELLE;
                }
 
            }
            public int Compare(Attribut x, Attribut y)
            {
                int index = helpers.BinarySearch(new AttributHelper { ATT_ID = x.ATT_ID });
                AttributHelper hx = helpers[index];
                index = helpers.BinarySearch(new AttributHelper { ATT_ID = y.ATT_ID });
                AttributHelper hy = helpers[index];
                //SortLevel1
                int s1 = hx.PARENT_LIBELLE.CompareTo(hy.PARENT_LIBELLE);
                if (s1 == 0)
                {
                    if (hx.ATT_ID == hy.ATT_PARENT_ID) return -1; //Parent before child
                    if (hx.ATT_PARENT_ID == hy.ATT_ID) return 1; //Child after parent
                    //SortLevel2
                    return hx.ATT_LIBELLE.CompareTo(hy.ATT_LIBELLE);
                }
                return s1;                
            }
        }
        public class Attribut
        {
            public int ATT_ID { get; set; }
            public string ATT_LIBELLE { get; set; }
            public int ATT_PARENT_ID { get; set; }
        }
    }
}
