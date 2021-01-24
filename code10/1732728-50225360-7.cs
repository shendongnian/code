        public partial class Form1 : Form
        {
            Model m_model;
            public Form1(string name, string candy, Model modelObj)
            {
                InitializeComponent();
                m_model = modelObj;
                //Not sure what you are doing here, but it will work
                string str = name + " selected : ";
                label1.Text = str;
                Console.WriteLine(name + " selected : " + candy);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //adding new chocolate to list;
                Chocolate newChocolate = new Chocolate(comboBoxChocolateSelection.SelectedItem.ToString(), 12.5, true, 2);
                m_model.AddChocolateInList(newChocolate);
                this.Close();
            }
        }
