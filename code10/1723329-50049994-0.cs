    namespace MM
    {
    public partial class frmSearch : Form
    {
        DataTable dt = new DataTable();
        DataRow[] passrow = new DataRow[1]; //to hold a particular row of datagridview
        bool jod = true; //True - add new record, false - edit record
        public frmSearch()
        {
            InitializeComponent();
        }
        
        private void frmSearch_Load(object sender, EventArgs e)
        {
            
        }
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            //Get DB records for textBox search
            dt = Talika.PanktiLa("select * from VM");
        }
        private void txtSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Press Enter to search", txtSearch);
        }
        
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //If ENTER is pressed
            //Go to ADD NEW button if textBox is empty
            //Load Vendor Master form if text is present
            if (e.KeyCode == Keys.Return)
                if (txtSearch.Text == String.Empty)
                    this.SelectNextControl(ActiveControl, true, true, true, true);
                else
                    Load_Vendor_Master();
            //If DOWN ARROW is pressed
            //Focus on listbox if textBox has text
            //Focus on ADD NEW button if textBox is blank
            if (e.KeyCode == Keys.Down)
            {
                if (txtSearch.Text != String.Empty)
                {
                    this.SelectNextControl(ActiveControl, true, true, true, true);
                    lstSearch.SelectedIndex = 0;
                }
                else if (txtSearch.Text == String.Empty)
                    this.SelectNextControl(ActiveControl, true, true, true, true);
            }
            //If ESC is pressed
            //Clear contents of textBox
            if (e.KeyCode == Keys.Escape)
                txtSearch.Text = String.Empty;
            //If RIGHT ARROW is pressed
            //Go to ADD NEW button
            if (e.KeyCode == Keys.Right)
                this.SelectNextControl(ActiveControl, true, true, true, true);
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Hide listbox if textbox is empty
            if (txtSearch.Text == String.Empty)
            {
                lstSearch.Hide();
                return;
            }
            //Proceed only if Vendor Master has records
            if (dt.Rows.Count != 0)
            {
                //Clear listbox so that new results can be populated.
                lstSearch.Items.Clear();
                //Populate listbox based on search results.
                foreach (DataRow dr in dt.Rows)
                {
                    //Have to convert to upper case, else search doesnt work effectively.
                    string s = dr["VNAME"].ToString().ToUpper();
                    //Populate listBox.
                    if (s.Contains(txtSearch.Text.ToUpper()))
                        lstSearch.Items.Add(s);
                }
                //Show listBox
                lstSearch.Visible = true;
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
                
        private void lstSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //If ENTER is pressed
            //Populate textBox with listBox item
            //Put focus back on textBox
            if (e.KeyCode == Keys.Enter)
            {
                //Populate textBox with selected item
                txtSearch.Text = lstSearch.SelectedItem.ToString();
                //Put focus on textBox
                this.SelectNextControl(ActiveControl, false, true, true, true);
                //Hide listBox
                lstSearch.Visible = false;
                //Load Vendor Master form
                Load_Vendor_Master();
            }
            //If cursor in on the first item of listBox
            //And UP ARROW is pressed
            //Highlight the textbox
            if (lstSearch.SelectedIndex == 0)
                if (e.KeyCode == Keys.Up)
                    this.SelectNextControl(ActiveControl, false, true, true, true);
            //If BACKSPACE is pressed
            //Delete last character of textBox
            //Set focus on textBox
            if (e.KeyCode == Keys.Back)
            {
                //Do this only if textbox is not empty
                if (txtSearch.Text != String.Empty)
                {
                    //Delete last char
                    txtSearch.Text = txtSearch.Text.Substring(0, txtSearch.Text.Length - 1);
                    //Set focus on textBox
                    this.SelectNextControl(ActiveControl, false, true, true, true);
                    //Set cursor at end of text
                    txtSearch.SelectionStart = txtSearch.TextLength;
                }
            }
            //If ESC is pressed
            //Hide listBox
            //Clear textBox contents
            //Set focus on textBox
            if (e.KeyCode == Keys.Escape)
            {
                lstSearch.Visible = false;
                txtSearch.Text = String.Empty;
                this.SelectNextControl(ActiveControl, false, true, true, true);
            }
            //If letter or digit is pressed
            //Type the char at the end of the text
            //Set focus on textBox
            bool isLetterOrDigit = char.IsLetterOrDigit((char) e.KeyCode);
            if (isLetterOrDigit ==  true)
            {
                //Add the char to text
                txtSearch.Text += (char)e.KeyCode;
                //Set cursor at end of text
                txtSearch.SelectionStart = txtSearch.TextLength;
                //Set focus on textBox
                this.SelectNextControl(ActiveControl, false, true, true, true);
            }
        }
        private void Load_Vendor_Master()
        {
            //Hide listbox
            lstSearch.Visible = false;
            //Read dt for matching records
            /* Replace("'", "''") helps to match names containing apostrophe.
            Single apostrophe is a string delimiter, 
            hence it is replaced with two single apostrophes which is interpreted as a single apostrophe */
            passrow = dt.Select("VNAME = '" + txtSearch.Text.Replace("'", "''") + "'");
            //Set flag
            jod = false; //Edit record
            //Load vendor master form
            //Do this only if datarow has rows (in this case, a single row)
            if (passrow.Length != 0)
            {
                frmVM frmVM_edit = new frmVM(passrow[0], jod);
                frmVM_edit.ShowDialog();
                //Get updated DB records for textBox search
                dt.Clear();
                txtSearch_Enter(null, null);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Set flag
            jod = true; //Add new record
            //Load form
            frmVM frmVM_add = new frmVM(null, jod);
            frmVM_add.ShowDialog();
            this.Close();
        }
        private void frmSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //Close form when ESC key is pressed
            //Do this only if textBox is blank
            //Because ESC is also used to clear textBox
            if (e.KeyCode == Keys.Escape)
                if (txtSearch.Text == String.Empty)
                    this.Close();
        }
        private void lstSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private void btnAdd_KeyDown(object sender, KeyEventArgs e)
        {
            //If RIGHT or LEFT arrow is pressed
            //Go to textBox
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
                this.SelectNextControl(ActiveControl, false, true, true, true);
        }
    }
    public static class Talika //This is declared in one form and can be accessed from any form in the entire solution without declaring it again
    {
        public static DataTable PanktiLa(string queryLe)
        {
            try
            {
                string connString = System.IO.File.ReadAllText(Application.StartupPath + "\\MM.ini") + " User ID = sa; Password = DEMO";
                DataTable dt_local = new DataTable();
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand(queryLe, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    conn.Open();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt_local);
                    return (dt_local);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please contact the program vendor with this error code:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (null);
            }
        }
    }
    }
