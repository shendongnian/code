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
    
                
                
                Random rand = new Random(); 
                for(int i = 0; i < 30;i++)
                {
                    int ra = rand.Next(10);
                    Attribut move = sortList[ra];
                    sortList.RemoveAt(ra);
                    sortList.Add(move);
                }
    
                sortList.Sort(new CompareAttribut(sortList, false));
    
                foreach (Attribut oneAtt in sortList)
                {
                    Console.WriteLine(oneAtt.ATT_ID + " " + oneAtt.ATT_LIBELLE + " " + oneAtt.ATT_PARENT_ID);
                }
    
            }
    
            public class CompareAttribut : IComparer<Attribut>
            {
                private bool order = false;
    
                private Dictionary<int, string> kHelpers = new Dictionary<int, string>();
                public CompareAttribut(List<Attribut> StartList, bool Order)
                {
                    order = Order;
                    foreach (Attribut a in StartList)
                    {
                        int key = a.ATT_ID;
                        string value = a.ATT_PARENT_ID > 0 ? StartList.Single(p => p.ATT_ID == a.ATT_PARENT_ID).ATT_LIBELLE : a.ATT_LIBELLE;
    
                        kHelpers.Add(key, value);
                    }
    
                }
    
                public int Compare(Attribut x, Attribut y)
                {
                    string xParentLib = kHelpers[x.ATT_ID];
                    string yParentLib = kHelpers[y.ATT_ID];
                    
                    //SortLevel1
                    int outcome = xParentLib.CompareTo(yParentLib) * (order ? 1 : -1);
                    if (outcome == 0)
                    {
                        if (x.ATT_ID == y.ATT_PARENT_ID) return -1; //Parent before child
                        if (x.ATT_PARENT_ID == y.ATT_ID) return 1; //Child after parent
                        //SortLevel2
                        return x.ATT_LIBELLE.CompareTo(y.ATT_LIBELLE) * (order ? 1 : -1);
                    }
                    return outcome ;                
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
