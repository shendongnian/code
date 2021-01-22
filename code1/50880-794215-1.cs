    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                listBox1.DataSource = GetFolder("D:\\Music\\");
            }
    
            private static List<string> GetFolder(string folder)
            {
                List<string> FileList = new List<string>();
                foreach (FileInfo file in new DirectoryInfo(folder).GetFiles("*.mp3", SearchOption.AllDirectories))
                    FileList.Add(file.FullName);
                return FileList;
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                StreamWriter sw = new StreamWriter("c:\\Media PlayList\\List.txt", true);
                wmp.URL = Convert.ToString(listBox1.SelectedItem);
                foreach (object o in listBox1.SelectedItems)
                    sw.WriteLine(DateTime.Now + " - " + o);
                sw.Close();
            }
        }
    }
