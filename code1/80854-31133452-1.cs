    using System.IO;
    namespace delete_the_folder
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Deletebt_Click(object sender, EventArgs e)
        {
            //the  first you should write the folder place
            if (Pathfolder.Text=="")
            {
                MessageBox.Show("ples write the path of the folder");
                Pathfolder.Select();
                //return;
            }
            FileAttributes attr = File.GetAttributes(@Pathfolder.Text);
            if (attr.HasFlag(FileAttributes.Directory))
                MessageBox.Show("Its a directory");
            else
                MessageBox.Show("Its a file");
            string path = Pathfolder.Text;
            FileInfo myfileinf = new FileInfo(path);
            myfileinf.Delete();
        
        }
       
    }
    }
 
