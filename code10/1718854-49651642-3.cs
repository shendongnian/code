    var list = new List<Model>();
    list.Add(new Model(1, 1));
    list.Add(new Model(2, 1));
    list.Add(new Model(2, 2));
    list.Add(new Model(3, 1));
    list.Add(new Model(3, 2));
    list.Add(new Model(3, 3));
    
    var notValidBranchIds = list.Where(x => x.DeptId == 2 || x.DeptId == 3).Select(x => x.BranchId);
    var result = list.Where(x => x.DeptId == 1 && !notValidBranchIds.Contains(x.BranchId)).Select(x => x.BranchId);
    
    // you can also use this. It solve the problem in a line
    var betterResult = list.GroupBy(x => new { x.DeptId })
       .Select(x => x.FirstOrDefault(a => a.DeptId == 1))
       .Where(y => y != null)
       .ToList();
