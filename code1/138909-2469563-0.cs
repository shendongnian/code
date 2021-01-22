    namespace TEST
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Thread th = new Thread(AccessList);
                th.Start(MylistBox);
            }
    
            void AccessList(Object O)
            {
                ListBox lBox = O as ListBox;
                for (int i = 0; i < lBox.Items.Count; i++)
                {
                    MessageBox.Show(lBox.Items[i].ToString());
                }
            }
        }
    }
