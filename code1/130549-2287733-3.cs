            Func<int?, string> GetParents = null;
            List<URClass> lstRoot = new List<URClass>();
            lstRoot.Add(new URClass() { Id = 1, Name = "a", ParentId = null, Path = "1" });
            lstRoot.Add(new URClass() { Id = 2, Name = "b", ParentId = 1, Path = "1" });
            lstRoot.Add(new URClass() { Id = 3, Name = "c", ParentId = 2, Path = "1" });
            lstRoot.Add(new URClass() { Id = 4, Name = "d", ParentId = 3, Path = "1" });
            lstRoot.Add(new URClass() { Id = 5, Name = "e", ParentId = 4, Path = "1" });
            GetParents = i =>
            {
                var str = string.Empty;
                var outt = lstRoot.Where(x => x.Id == i).Select(x=>new {x.Name,x.ParentId });
                foreach (var lst in outt)
                {
                    str += lst.Name;
                    if (lst.ParentId != null)
                    {
                          var outts = GetParents(lst.ParentId);
                          str += "," + outts;
                    }                    
                }
                return str;
                
            };          
            var ks = from p in lstRoot
                     join q in lstRoot on p.Id equals q.ParentId
                     select new { q.Id, parentName = p.Name, parentid=p.Id, gpid=p.ParentId };
            List<string> RelationShip = new List<string>();
            
            foreach (var lst in ks)
            {
                var str = lst.parentName;
                if (lst.gpid != null)
                {
                     var prnt = GetParents(lst.gpid);
                     if (prnt != null)
                        str += "," + prnt;                   
                }
                str += "/" + lst.Id;
                RelationShip.Add(str); 
            }
            foreach (var ret in RelationShip)
                Console.WriteLine(ret);
