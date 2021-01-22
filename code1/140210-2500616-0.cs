    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TreeViewRecurse
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
             RecurseTreeViewAndSumValues(treeView1.Nodes);
          }
    
          public void RecurseTreeViewAndSumValues(TreeNodeCollection treeNodeCol)
          {
             int tree_node_sum = 0;
             foreach (TreeNode tree_node in treeNodeCol)
             {
                if (tree_node.Nodes.Count > 0)
                {
                   RecurseTreeViewAndSumValues(tree_node.Nodes);
                }
                string[] node_split = tree_node.Text.Split(' ');
                string num = node_split[node_split.Length - 1];
                int parse_res = 0;
                bool able_to_parse = int.TryParse(num, out parse_res);
                if (able_to_parse)
                {
                   tree_node_sum += parse_res;
                }
             }
             if (treeNodeCol[0].Parent != null)
             {
                string[] node_split_parent = treeNodeCol[0].Parent.Text.Split(' ');
                node_split_parent[node_split_parent.Length - 1] = tree_node_sum.ToString();
                treeNodeCol[0].Parent.Text = string.Join(" ", node_split_parent);
             }
          }
       }
    }
