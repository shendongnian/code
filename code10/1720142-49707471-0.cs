    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace TestingApplication
    {
        public partial class frmTreeView : Form
        {
            TreeView tr = new TreeView();
            TreeNode tn = new TreeNode();
            TreeNode tn1 = new TreeNode();
    
            public frmTreeView()
            {
                InitializeComponent();
            }
    
            private void frmTreeView_Load(object sender, EventArgs e)
            {
                tr.CheckBoxes = true;
                tn.Text = "fruit";
                tn1.Text = "snack";
                tn1.Nodes.Add("meat");
                tn1.Nodes.Add("other");
                tn.Nodes.Add("apple");
                tn.Nodes.Add("orange");
                this.tr.Nodes.Add(tn);
                this.tn.Nodes.Add(tn1);
                this.Controls.Add(tr);
                this.tr.NodeMouseClick += new TreeNodeMouseClickEventHandler(tr_NodeMouseClick);
            }
    
            private void tr_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
                TreeNode clickedNode = e.Node;
                if (clickedNode.Checked)
                {
                    if (clickedNode.Text.Equals("apple"))
                    {
                        MessageBox.Show("you checked" + clickedNode.Text + "");
                    }
                    else if (clickedNode.Text.Equals("orange"))
                    {
                        MessageBox.Show("you checked" + clickedNode.Text + "");
                    }
                }
            }
    
        }
    }
