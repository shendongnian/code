    public class Group
    {
        public int group;
        public int row;
        public double highestRelDistance;
    
        public Group(int _group)
        {
            group = _group;
        }
    
    }
    
    public class Tree
    {
        public string name;
        public Group group = new Group(0);
        public int orderInGroup;
        public double x;
        public double y;
        public string type;
        public double relDistance;
    }
    public static void FitTreesToLine(List<Tree> treesList, out double m, out double c)
    {
        double[] xdata = treesList.Select(x => x.x).ToArray();
        double[] ydata = treesList.Select(x => x.y).ToArray();
        Tuple<double, double> p = Fit.Line(xdata, ydata);
        double a = p.Item1; // == 10; intercept
        double b = p.Item2; // == 0.5; slope
        m = b;
        c = a;
    }
    public static double FindDistanceBetweenPointAndLine(double m, double c, double point_x, double point_y )
    {
        double line_start_x = point_x * 0.5;
        double line_start_y = m * line_start_x + c;
        double line_end_x = point_x * 1.5;
        double line_end_y = m * line_end_x + c;
        double distance = Math.Abs((line_end_x - line_start_x) * (line_start_y - point_y) - (line_start_x - point_x) * (line_end_y - line_start_y)) /
                Math.Sqrt(Math.Pow(line_end_x - line_start_x, 2) + Math.Pow(line_end_y - line_start_y, 2));
        return (distance);
    }
     public static void DoCalculations(List<Tree> treeList)
     {
        //Calculate groups
        Group curGroup = new Group(1);
        groupList.Add(curGroup);
        int searchFailures = 0;
        treeGrouping:
        List<Tree> noGroupList = treeList.Where(x => x.group.group == 0).ToList();
        List<Tree> closeTreeList = new List<Tree>();
        if (noGroupList.Count() >= 3 && searchFailures < 1000)
        {
            var refTree = noGroupList[0];
            closeTreeList.Add(refTree);
            for (int i = 1; i < noGroupList.Count(); i++)
            {
                double distance = Math.Sqrt(Math.Pow(refTree.x - noGroupList[i].x, 2) + Math.Pow(refTree.y - noGroupList[i].y, 2));
                if (distance <= 7)
                {
                    closeTreeList.Add(noGroupList[i]);
                    if (closeTreeList.Count() == 2)
                    {
                        //Fit linear curve
                        double m = 0;
                        double c = 0;
                        FitTreesToLine(closeTreeList, out m, out c);
                        //Find all points that is close to the line in original tree list
                        for (int j = 0; j < noGroupList.Count(); j++)
                        {
                            double distanceFromLine = FindDistanceBetweenPointAndLine(m, c, noGroupList[j].x, noGroupList[j].y);
                            if (distanceFromLine <= 8)
                            {
                                noGroupList[j].group = curGroup;
                            }
                        }
                        //Iterate current group
                        curGroup = new Group(curGroup.group + 1);
                        groupList.Add(curGroup);
                        goto treeGrouping;
                    }
                }
            }
            refTree.group.group = 9999999;
            //curGroup = new Group(curGroup.group + 1);
            //groupList.Add(curGroup);
            searchFailures++;
            goto treeGrouping;
        }
        //Order trees within their groups
        foreach (var group in groupList)
        {
            var groupTreeList = treeList.Where(x => x.group == group).OrderBy(x => x.y).ToList();
            for (int i = 0;i < groupTreeList.Count();i++)
            {
                groupTreeList[i].orderInGroup = i + 1;
            }
        }
        //Get max group rel distance
        foreach (var group in groupList)
        {
            var items = treeList.Where(x => x.group == group);
            if (items.Count() > 0)
            {
                group.highestRelDistance = items.OrderBy(x=>x.orderInGroup).Last().x;
            }
        }
        //Order tree groups into rows
        groupList = groupList.OrderBy(x => x.highestRelDistance).ToList();
        for (int i = 0;i < groupList.Count();i++)
        {
            var items = treeList.Where(x => x.group == groupList[i]).ToList();
            foreach (var item in items)
            {
                item.group.row = i;
            }
        }
        //Generate tree names
        foreach (var tree in treeList)
        {
            tree.name = "(" + tree.group.row.ToString().PadLeft(2,'0') + "-" + tree.orderInGroup.ToString().PadLeft(3, '0') + ")";
        }
        //Order list
        treeList = treeList.OrderBy(x => x.group.row).ThenBy(x => x.orderInGroup).ToList();
