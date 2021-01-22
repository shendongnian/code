    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TreeViewApp
    {
        public static class TreeNodeCollectionExtensions
        {
            public static TreeNode[] FindExact(this TreeNodeCollection coll, string keytofind)
            {
                TreeNode[] retval;
    
                if (String.IsNullOrWhiteSpace(keytofind) || coll == null)
                {
                    retval = new TreeNode[0];
                }
                else
                {
                    TreeNode[] badfinds = coll.Find(keytofind, true);
    
                    List<TreeNode> goodfinds = new List<TreeNode>();
                    foreach (TreeNode bad in badfinds)
                    {
                        if (bad.Name == keytofind)
                            goodfinds.Add(bad);
                    }
                    retval = goodfinds.ToArray();
    
                }
                return retval;
            }
        }
    }
