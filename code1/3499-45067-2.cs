    namespace AutoComplete
    {
        public partial class Main : Form
        {
            //so you don't have to address "txtMain.AutoCompleteCustomSource" every time
            AutoCompleteStringCollection acsc;
            public Main()
            {
                InitializeComponent();
    
                //Set to use a Custom source
                txtMain.AutoCompleteSource = AutoCompleteSource.CustomSource;
                //Set to show drop down *and* append current suggestion to end
                txtMain.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //Init string collection.
                acsc = new AutoCompleteStringCollection();
                //Set txtMain's AutoComplete Source to acsc
                txtMain.AutoCompleteCustomSource = acsc;
            }
    
            private void txtMain_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Only keep 10 AutoComplete strings
                    if (acsc.Count < 10)
                    {
                        //Add to collection
                        acsc.Add(txtMain.Text);
                    }
                    else
                    {
                        //remove oldest
                        acsc.RemoveAt(0); 
                        //Add to collection
                        acsc.Add(txtMain.Text);
                    }
                }
            }
    
            private void Main_FormClosed(object sender, FormClosedEventArgs e)
            {
                //open stream to AutoComplete save file
                StreamWriter sw = new StreamWriter("AutoComplete.acs");
    
                //Write AutoCompleteStringCollection to stream
                foreach (string s in acsc)
                    sw.WriteLine(s);
    
                //Flush to file
                sw.Flush();
    
                //Clean up
                sw.Close();
                sw.Dispose();
            }
    
            private void Main_Load(object sender, EventArgs e)
            {
                //open stream to AutoComplete save file
                StreamReader sr = new StreamReader("AutoComplete.acs");
    
                //initial read
                string line = sr.ReadLine();
                //loop until end
                while (line != null)
                {
                    //add to AutoCompleteStringCollection
                    acsc.Add(line);
                    //read again
                    line = sr.ReadLine();
                }
    
                //Clean up
                sr.Close();
                sr.Dispose();
            }
        }
    }
