    namespace LastEnumItem
    {
        public partial class Form1 : Form
        {
            List<string> lst = new List<string>(); 
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                for(int i=0; i<=10 ; i++)
                {
                    lst.Add("string " + i.ToString());
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string lastitem = lst[lst.Count-1];
                foreach (string str in lst)
                {
                    if (lastitem != str)
                    {
                        // do something
                    }
                    else
                    {
                        MessageBox.Show("Last Item :" + str);
                    }
                }
            }
    
    
        }
    }
