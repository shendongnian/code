    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    namespace TestingJojoWinForms
    {
    public partial class frmRedemption : Form
    {
        public frmRedemption()
        {
            InitializeComponent();
        }
        private void frmRedemption_Load(object sender, EventArgs e)
        {
            DataTable dtResult = new DataTable("Result");
            dtResult.Columns.Add("EntryID");
            dtResult.Columns.Add("FirstName");
            dtResult.Columns.Add("LastName");
            dtResult.Columns.Add("Alias");
            dtResult.Columns.Add("SMTPAddress");
            dtResult.Columns.Add("JobTitle");
            dtResult.Columns.Add("Address");
            dtResult.Columns.Add("StreetAddress");
            
            Redemption.RDOSessionClass session = new Redemption.RDOSessionClass();
            session.Logon(@"your_account_name", "your_password", false, false, 0, false);
            for(int index = 1; index <= session.AddressBook.GAL.AddressEntries.Count; index++) 
            {
                Redemption.RDOAddressEntryClass entry = (Redemption.RDOAddressEntryClass)session.AddressBook.GAL.AddressEntries.Item(index);
                dtResult.Rows.Add(entry.EntryID, entry.FirstName, entry.LastName, entry.Alias, entry.SMTPAddress, entry.JobTitle, entry.Address, entry.StreetAddress);
            }
            session.Logoff();
            this.dataGridView1.DataSource = dtResult;
        }
    }
    }
