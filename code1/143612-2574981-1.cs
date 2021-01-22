          alstout.AddRange(  (
                     from n in docHarf.SelectNodes("//adatesmi")
                     select new PossibilityJavamed(){
                        derv = n.Attributes["derv"].Value;
                        dervt = n.Attributes["dervt"].Value;
                        num = n.Attributes["num"].Value;
                        gend = n.Attributes["gend"].Value;
                     }
                ).ToList());
