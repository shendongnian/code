    namespace Tree
    {
        public partial class Form1 : Form
        {
            private SortedSet<int> binTree = new SortedSet<int>();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Insert(int no)
            {
                binTree.Add(no);
            }
    
            private void Print()
            {
                foreach (int i in binTree)
                {
                    Console.WriteLine("\t{0}", i);
                }
            }
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
                Insert(Int32.Parse(tbxValue.Text));
                tbxValue.Text = "";
            }
    
            private void btnPrint_Click(object sender, EventArgs e)
            {
                Print();
            }
        }
    }
