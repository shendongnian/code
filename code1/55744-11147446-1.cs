    public static TreeNode[] mergeTrees(TreeNode[] target, TreeNode[] source)
            {
                if (source == null || source.Length == 0)
                {
                    return target;
                }
                if (target == null || target.Length == 0)
                {
                    return source;
                }
                bool found;
                foreach (TreeNode s in source)
                {
                    found = false;
                    foreach (TreeNode t in target)
                    {
                        if (s.Text.CompareTo(t.Text) == 0)
                        {
                            found = true;
                            TreeNode[] updatedNodes = mergeTrees(Util.treeView2Array(t.Nodes), Util.treeView2Array(s.Nodes));
                            t.Nodes.Clear();
                            t.Nodes.AddRange(updatedNodes);
                            break;
                        }
                    }
                    if (!found)
                    {
                        TreeNode[] newNodes = new TreeNode[target.Length + 1];
                        Array.Copy(target, newNodes, target.Length);
                        newNodes[target.Length] = s;
                        target = newNodes;
                    }
                }
                return target;
            }
