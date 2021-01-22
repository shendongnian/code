    public static void PopulateTreeView(Dictionary<int, List<Employee>> employees, int bossId, TreeNodeCollection nodes)
    {
    	if (!employees.ContainsKey(bossId)) return;
    
    	foreach (Employee e in employees[bossId])
    	{
    		TreeNode tn = (TreeNode)e;
    		nodes.Add(tn);
    		PopulateTreeView(employees, e.Id, tn.Nodes);
    	}
    }
