        using System;
        using System.Collections.Generic;
        using System.Linq;
        namespace ConsoleApp9
        {
        class Program
        {
        static void search(string search_query)
        {
        //////////////////////////////////////////////////
        var terms = search_query.Split(' ');
        //////////////////////////////////////////////////
        var Ids1 = db.Orgs.
        Where(w => w.Title.Contains(search_query))
        .Select(s => s.Id).ToList();
        var Ids2 = db.Database
        .SqlQuery<int>(getWhere("Title", "AND"), terms)
        .ToList();
        var Ids3 = db.Database
        .SqlQuery<int>(getWhere("Title", "OR"), terms)
        .ToList();
        var Ids4 = db.Database
        .SqlQuery<int>(getWhere("Keywords", "OR"), terms)
        .ToList();
        var Ids5 = db.Orgs
        .Where(w => w.Content.Contains(search_query))
        .Select(s => s.Id).ToList();
        var ordered_ids = reorderList(Ids1, Ids2, Ids3, Ids4, Ids5);
        var OrderedData = db.Database.SqlQuery<Org>(getOrdered(ordered_ids)).ToList();
        //////////////////////////////////////////////////
        foreach (var item in OrderedData)
        {
            Console.WriteLine($"{item.Id} - {item.Title} - {item.ContactPerson } - {item.Keywords } - {item.Content  }");
        }
        //////////////////////////////////////////////////
        Console.ReadLine();
        //////////////////////////////////////////////////
        string getWhere(string _column, string _oprator)
        {
            var val = "Select Id From Orgs where ";
            for (int i = 0; i < terms.Length; i++)
            {
                if (i > 0) val += @" " + _oprator + " ";
                val += @" " + _column + " LIKE '%' + {" + i + "} +'%'  ";
            }
            return val;
        }
        //////////////////////////////////////////////////
        string getOrdered(int[] _ids_ordered)
        {
            var val = "Select * From Orgs where ";
            val += " Id in ";
            for (int i = 0; i < _ids_ordered.Length; i++)
            {
                if (i == 0) val += "( ";
                if (i > 0) val += " , ";
                val += _ids_ordered[i];
                if (i == terms.Length - 1) val += " ) ";
            }
            val += " ORDER BY CASE id ";
            for (int i = 0; i < _ids_ordered.Length; i++)
            {
                val += " WHEN " + _ids_ordered[i] + " THEN " + i;
            }
            val += " ELSE " + _ids_ordered.Length + " END ";
            return val;
        }
        //////////////////////////////////////////////////
        int[] reorderList(List<int> _Ids1, List<int> _Ids2,
            List<int> _Ids3, List<int> _Ids4, List<int> _Ids5)
        {
            var idsDic = new Dictionary<int, int>();
            var idsArr = new List<int>[5] { Ids1, Ids2, Ids3, Ids4, Ids5 };
            for (int i = 0; i < 5; i++)
            {
                idsArr[i].ForEach(id =>
                {
                    if (!idsDic.TryGetValue(id, out int val))
                        idsDic.Add(id, idsDic.Count());
                });
            };
            var o_ids = idsDic.OrderByDescending(o => o.Value)
                    .Select(s => s.Key).ToArray();
            return o_ids;
        }
        }
        static Model1 db = new Model1();
        static void Main(string[] args)
        {
        string search_quer = "Alcohol Support";
        Console.WriteLine($"searching for {search_quer}");
        search("Alcohol Support");
        }
        }
        }
   
