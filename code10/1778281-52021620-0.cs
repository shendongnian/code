<!-- language: lang-css -
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
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                XDocument doc = XDocument.Load(FILENAME);
                XElement dir = doc.Root;
                TreeNode node = new TreeNode((string)dir.Attribute("name"));
                treeView1.Nodes.Add(node);
                GetTree(dir, node);
                treeView1.ExpandAll();
            }
            public static void GetTree(XElement dir, TreeNode node)
            {
                foreach (XElement child in dir.Elements("dir"))
                {
                    TreeNode childNode = new TreeNode((string)child.Attribute("name"));
                    node.Nodes.Add(childNode);
                    GetTree(child, childNode);
                }
            }
        }
    }
