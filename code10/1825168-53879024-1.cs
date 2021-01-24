            List<Class> ListOfClass = new List<Class>();   
            
            var Grouping = ListOfClass.GroupBy(x => x.Name).Select(group => new {
                Name = group.Key,
                Value = group.Max(x => x.Value)
            }).ToList();
