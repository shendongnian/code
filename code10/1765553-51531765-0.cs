        List<Object> curList;
    
        if (!tree.HasChildNodes)
            return list;
        else
        {
            if (list==null)
            {
                list = new List<Object>;
                curList = list;
            } 
            else
            {
                curList = new List<Object>;
                list.Add(curList);
            }
    
            foreach(node in tree.ChildNodes)
            {
                curList.Add(node.Name);
                curList.Add(GetNestedListFromTree(node.GetSubtree, curList));
            }
    
            return curList;
        }
    }
