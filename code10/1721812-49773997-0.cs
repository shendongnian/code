    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication15
    {
        public partial class Form1 : Form
        {
            const int MAX_LEVEL = 3;
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                XDocument doc = XDocument.Load(FILENAME);
                XElement root = doc.Root;
                TreeNode newNode = new TreeNode();
                newNode.Text = root.Name.LocalName;
                treeView1.Nodes.Add(newNode);
                int level = 1;
                AddRecursive(root, newNode, level);
                treeView1.ExpandAll();
            }
            public void AddRecursive(XElement element, TreeNode parent, int level)
            {
                foreach (XElement child in element.Elements())
                {
                    TreeNode newNode = new TreeNode();
                    newNode.Text = child.Name.LocalName;
                    parent.Nodes.Add(newNode);
                    if (level < MAX_LEVEL)
                    {
                        AddRecursive(child, newNode, level + 1);
                    }
                }
            }
        }
    }
