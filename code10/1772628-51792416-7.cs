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
                sortList.Add(new Attribut() { ATT_ID = 369, ATT_LIBELLE = "Site", ATT_PARENT_ID = 367 });
                sortList.Add(new Attribut() { ATT_ID = 370, ATT_LIBELLE = "Materiel", ATT_PARENT_ID = 367 });
                sortList.Add(new Attribut() { ATT_ID = 371, ATT_LIBELLE = "Machine", ATT_PARENT_ID = 366 });
                sortList.Add(new Attribut() { ATT_ID = 372, ATT_LIBELLE = "Affaire parent", ATT_PARENT_ID = 366 });
    
    
    
                Random rand = new Random();
                for (int i = 0; i < 30; i++)
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
                private class AttributTree
                {
                    private Attribut self;
                    public AttributTree(Attribut Self)
                    {
                        self = Self;
                    }
                    public Attribut Self
                    {
                        get { return self; }
                    }
                    public AttributTree Parent { get; set; }
    
                    public string [] SortorderLib { get; set; }
             
                }
    
                private bool order = false;
    
                private Dictionary<int,AttributTree> kHelpers = new Dictionary<int, AttributTree>();
                public CompareAttribut(List<Attribut> StartList, bool Order)
                {
     
                    order = Order;
    
                    foreach (Attribut a in StartList)
                    {
                        int key = a.ATT_ID;
                        AttributTree at = new AttributTree(a);
                        
    
                        //string value = a.ATT_PARENT_ID > 0 ? StartList.Single(p => p.ATT_ID == a.ATT_PARENT_ID).ATT_LIBELLE : a.ATT_LIBELLE;
    
                        kHelpers.Add(key, at);
                    }
    
                    //Create the tree
                    foreach (AttributTree at in kHelpers.Values)
                    {
                        at.Parent = kHelpers[at.Self.ATT_ID];
                    }
    
                    foreach (AttributTree at in kHelpers.Values)
                    {
                        List<string> libelles = new List<string>();
                        libelles.Add(at.Self.ATT_LIBELLE);
                        AttributTree up = at;
    
                        while (up.Self.ATT_PARENT_ID != 0)
                        {
                            up = kHelpers[up.Self.ATT_PARENT_ID];
                            libelles.Insert(0, up.Self.ATT_LIBELLE);
                        }
    
                        at.SortorderLib = libelles.ToArray();
                    }
    
    
    
                }
    
                public int Compare(Attribut x, Attribut y)
                {
                    string[] xParentLib = kHelpers[x.ATT_ID].SortorderLib;
                    string[] yParentLib = kHelpers[y.ATT_ID].SortorderLib;
    
                    int i = 0;
    
                    int outcome = 0;
                    while (outcome == 0)
                    {
                        if (i == xParentLib.Length) outcome = -1;//x above y
                        else if (i == yParentLib.Length) outcome = 1;//x  under y
                        else outcome = xParentLib[i].CompareTo(yParentLib[i]);
                        if (outcome == 0)
                        {
                            i++;
                            continue;
                        }
                        break;
                    }
                    return outcome * (order ? 1 : -1); 
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
