    public class SO50846156
    {
        public TreeNode Test(String[] data)
        {
            var root = new TreeNode();
            foreach (var line in data)
            {
                var split = line.Split('>');
                var count = split.Length;
                var item = root.Nodes.Add(split[0]);
                if (1 < count)
                {
                    var subCat = item.Nodes.Add(split[1]);
                    if (2 < count)
                    {
                        var catName = subCat.Nodes.Add(split[2]);
                    }
                }
            }
            return root;
        }
    }
