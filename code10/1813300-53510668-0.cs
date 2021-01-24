    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    
    
    namespace BugTracker
    {
        struct BugTrackers
        {
            public string BugsName;
            public string BugsDesc;
          
        }
    
        public partial class YoungKidsBugTracker : Form
        {
            // Field to hold a list of BugTrackers objects
            private List<BugTrackers> Bugs = new List<BugTrackers>();
            private int index; // index fo selected bugs in combobox
    
            public YoungKidsBugTracker()
            {
                InitializeComponent();
            }
    
            private void ReadFile()
            {
                try
                {
                    //Declare a varialble to hold Bugs Name
                    StreamReader inputFile;   // To Read the file
                    string line;              // To hold a line from the file
    
                    // Create an instance of the Bug Accounts
                    BugTrackers entry = new BugTrackers();
    
                    // Create a delimeter array
                    char[] delim = { ',' };
    
                    // Open the file and get a StreamReader Object
                    inputFile = File.OpenText("smBugs.txt");
    
                    // Read the file's contents
                    while (!inputFile.EndOfStream)
                    {
                        // Read a line from the file
                        line = inputFile.ReadLine();
    
                        // Tokenize the line
                        string[] tokens = line.Split(delim);
    
                        // Stores the tokens in the entry object
                        entry.BugsName = tokens[0];
                        entry.BugsDesc = tokens[1];
    
                        // Add the entry object to the combobox
                        Bugs.Add(entry);
                    }
                    // Close the File
                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    // Display an error message
                    MessageBox.Show(ex.Message);
                }
            }
    
            private void lstBugs_SelectedIndexChanged(object sender, EventArgs e)
            {
                // Get the index of the sselected item
                index = lstBugs.SelectedIndex;
    
                // Display Bug Information
                DisplayBugs();
            }
    
            private void DisplayBugs()
            {
                //Show Data
                txtBugsName.Text = Bugs[index].BugsName;
                rtxtBugDesc.Text = Bugs[index].BugsDesc.ToString();
            }
    
            private void YoungKidsBugTracker_Load(object sender, EventArgs e)
            {
                // Read the Bugs.txt file
                ReadFile();
    
                // Display Bug Information
                BugNameDisplay();
            }
            
            private void btnEdit_Click(object sender, EventArgs e)
            {
                BugTrackers cs = Bugs[index];
               // DisplayBugs();
                // Update datafile
                UpdateBugsInfo();
            }
            private void UpdateBugsInfo()
            {
                if (lstBugs.SelectedIndex > -1)
                {
                    System.IO.StreamWriter sw = new System.IO.StreamWriter("smBugs.txt");
    
                    for (int i = 0; i <= Bugs.Count - 1; i++)
                    {
                        sw.Write(Bugs[i].BugsName);
                        sw.Write(",");
                        sw.WriteLine(Bugs[i].BugsDesc);
                       // sw.Write(Environment.NewLine);
                    }
                    sw.Close();
                }
            }
    
            private void BugNameDisplay()
            {
                // Display the list of Bug Names in the List Control
                foreach (BugTrackers entry in Bugs)
                {
                    lstBugs.Items.Add(entry.BugsName );
                }
            }
    
            private void btnAdd_Click(object sender, EventArgs e)
            {
    
            }
    
    
        }
    }
