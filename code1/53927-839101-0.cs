    var setterCount =
                (from s in typeof (Entity).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                 where s.GetSetMethod().IsPublic
                 select s)
                    .Count();
				
