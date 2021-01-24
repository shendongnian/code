    internal class TempResult
    {
        public string Name { get; set; }
        public int? id { get; set; }
        public int? AddressId { get; set; }
        public string groupName { get; set; }
    }
    
    var tempResults = db.Database.SqlQuery<TempResult>(
        @"Select p.Name, p.ProductGroupID as GroupID, g.Name as GroupName
    FROM Products as p
    LEFT JOIN ProductGroups as g
        ON p.ProductGroupID = g.ProductGroupID",
        objectParameterList.ToArray()).ToList();
    
    querySearchResult = tempResults.Select(t => new SearchResult
    {
        Name = t.Name,
        Group = new GroupView 
            {
                id = t.id,
                Name = t.groupName,
            }
    }
