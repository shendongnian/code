               string[] ids = parents.Select(x => x.Children.Select(y => y.Id)).SelectMany(x => x).OrderBy(x => x).Distinct().ToArray();
                Dictionary<string, List<Parent>> dict = new Dictionary<string, List<Parent>>();
                foreach (string id in ids)
                {
                    List<Parent> parentId = parents.Where(x => x.Children.Any(y => y.Id == id)).ToList();
                    dict.Add(id, parentId);
                }
