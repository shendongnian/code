    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    namespace CheckFileSizes
    {
        public partial class Form1 : Form
        {
            const int FILE_SIZE_CHECK = 10000000;
            const int FILE_COUNT_CHECK = 10000;
            public Form1()
            {
                InitializeComponent();
                folderBrowserDialog1.SelectedPath = @"c:\temp";
                textBoxTotalFolderSizeMin.Text = FILE_SIZE_CHECK.ToString();
                textBoxNumberOfFilesMin.Text = FILE_COUNT_CHECK.ToString();
                
            }
            private void buttonBrowseForFolder_Click(object sender, EventArgs e)
            {
                folderBrowserDialog1.ShowDialog();
                textBoxFolderName.Text = folderBrowserDialog1.SelectedPath;
            }
            private void buttonMakeTree_Click(object sender, EventArgs e)
            {
                if (Directory.Exists(textBoxFolderName.Text))
                {
                    MyDirectory root = MyDirectory.root;
                    TreeNode rootNode = MakeTreeRecursive(textBoxFolderName.Text, root);
                    textBoxTotalNumberOfFiles.Text = root.totalNumberOfFiles.ToString();
                    textBoxTotalSize.Text = ((long)root.totalSize).ToString();
                    if (rootNode == null)
                    {
                        string rootNodeText = string.Format("Folder: '{0}', Number of Files: '{1}', File Size: '{2}'",
                            textBoxFolderName.Text,
                            textBoxTotalNumberOfFiles.Text,
                            textBoxTotalSize.Text
                        );
                        rootNode = new TreeNode(rootNodeText);
                    }
                    treeView1.Nodes.Add(rootNode);
                    treeView1.ExpandAll();
                    
                }
            }
            private TreeNode MakeTreeRecursive(string folder, MyDirectory myDirectory)
            {
                TreeNode node = null;
                myDirectory.name = folder.Substring(folder.LastIndexOf("\\") + 1);
                DirectoryInfo dInfo = new DirectoryInfo(folder);
                myDirectory.numberOfFiles = 0;
                myDirectory.size = 0.0f;
                try
                {
                    foreach (FileInfo fInfo in dInfo.GetFiles())
                    {
                        try
                        {
                            float fSize = fInfo.Length;
                            myDirectory.size += fSize;
                            myDirectory.numberOfFiles += 1;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error : Cannot Access File '{0}'", fInfo.Name);
                        }
                    }
                    myDirectory.totalSize = myDirectory.size;
                    myDirectory.totalNumberOfFiles = myDirectory.numberOfFiles;
                    foreach (string subFolder in Directory.GetDirectories(folder))
                    {
                        if (myDirectory.children == null) myDirectory.children = new List<MyDirectory>();
                        MyDirectory childDirectory = new MyDirectory();
                        myDirectory.children.Add(childDirectory);
                        TreeNode childNode = MakeTreeRecursive(subFolder, childDirectory);
                        if (childNode != null)
                        {
                            if (node == null)
                            {
                                node = new TreeNode();
                            }
                            node.Nodes.Add(childNode);
                        }
                        myDirectory.totalSize += childDirectory.totalSize;
                        myDirectory.totalNumberOfFiles += childDirectory.totalNumberOfFiles;
                    }
                }
                catch
                {
                    Console.WriteLine("Error : Cannot Access Folder '{0}'", dInfo.Name);
                }
                if ((myDirectory.totalNumberOfFiles >= long.Parse(textBoxNumberOfFilesMin.Text)) || myDirectory.totalSize >= float.Parse(textBoxTotalFolderSizeMin.Text))
                {
                    if (node == null)
                    {
                        node = new TreeNode();
                    }
                    string childNodeText = string.Format("Folder: '{0}', Number of Files: '{1}', File Size: '{2}'",
                        folder,
                        myDirectory.totalNumberOfFiles,
                        myDirectory.totalSize
                    );
                    node.Text =  childNodeText;
                }
                return node;
            }
        }
        public class MyDirectory
        {
            public static MyDirectory root = new MyDirectory();
            public List<MyDirectory> children { get; set; }
            public string name { get; set; }
            public long totalNumberOfFiles = 0;
            public int numberOfFiles = 0;
            public float size = 0.0f;
            public float totalSize = 0.0f;
        }
    }
