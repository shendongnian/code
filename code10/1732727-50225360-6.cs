            public partial class MainNavigation : Form
            {
                private Model m_modelObj;
                public MainNavigation(Model modelObj)
                {
                    InitializeComponent();
                    m_modelObj = modelObj;
                    //subscribing an even of Model class, 
                    //this will handle your logic what you want to perform on adding new Chocolate
                    m_modelObj.ChocolateAdded += m_modelObj_ChocolateAdded;
                }
                void m_modelObj_ChocolateAdded(Chocolate newChocolate)
                {
                    //perform your task what you want to do with newly added chocolate
            
                    //if you want whole list of chocolates
                    List<Chocolate> chocolateList = m_modelObj.ChocolateList;
                }
                private void btnProcessCandySelection_Click(object sender, EventArgs e)
                {
                    string candy = comboBoxCandySelection.SelectedItem.ToString();
                    Form1 aForm1 = new Form1(textBoxName.Text, candy, m_modelObj);
                    aForm1.ShowDialog();
                }
            }
