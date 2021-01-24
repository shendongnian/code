     public List<TreeNode> MainNodes(List<Levels> strut, int level){
        List<TreeNode> parentNode = new List<TreeNode>();
        for(int x = 0; x< strut.Count; x++){
            var data = strut[x];
            if(data.Level == level){
                TreeNode nodeC = new TreeNode();
                nodeC.Name = strut[x].Index.ToString(); //Index value from struct
                if(x + 1 < strut.Count){ 
                    if(strut[x+1].Level > level){
                        var newArray = new List<Levels>(strut);
                        newArray.RemoveAt(x);
                        nodeC.Nodes.AddRange(MainNodes(newArray, level + 1);
                    }
                }
                parentNode.Add(nodeC);
            }
        }
        return parentNode;
    }
