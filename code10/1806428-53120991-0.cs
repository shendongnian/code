    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication24
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                List<string> input = new List<string>() {
                   @"\Parent1\child1\childA\",
                   @"\Parent1\child1\childB\",
                   @"\Parent1\child2\childA\",
                   @"\Parent1\child2\childC\",
                   @"\Parent2\child3\child4\childE",
                   @"\Parent2\child4\child1\child6\child7"
                };
                List<List<string>> splitInputs = input.Select(x => x.Split(new char[] { '\\' }).ToList()).ToList();
                TreeNode root = null;
                treeView1.Nodes.Clear();
                RecursiveAdd(root, splitInputs);
                treeView1.ExpandAll();
                
            }
            public void RecursiveAdd(TreeNode parent, List<List<string>> paths)
            {
                var folders = paths.GroupBy(x => x[0]).ToList();
                foreach (var folder in folders)
                {
                    TreeNode node = new TreeNode(folder.Key);
                    if (parent == null)
                    {
                        treeView1.Nodes.Add(node);
                    }
                    else
                    {
                        parent.Nodes.Add(node);
                    }
                    List<List<string>> childNodes = folder.Select(x => x.Skip(1).ToList()).ToList();
                    if (childNodes.Count > 1)
                    {
                        RecursiveAdd(node, childNodes);
                    }
                }
            }
        }
    }
