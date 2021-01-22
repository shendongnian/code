    namespace datagridviewexpandcelldynamically
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
            {
    
                int origColumnWidth = dataGridView1.Columns[e.ColumnIndex].Width;
    
                dataGridView1.Columns[e.ColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
    
                dataGridView1.Columns[e.ColumnIndex].Width = origColumnWidth;
    
                if (dataGridView1.CurrentCell == null) dataGridView1.CurrentCell.Value = "";
    
            }
    
            private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                dataGridView1.Columns[e.ColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
    
            private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
    
                if (e.Control is TextBox)
                {
                    var tbox = (e.Control as TextBox);
    
                    // De-register the event FIRST so as to avoid multiple assignments (necessary to do this or the event
                    // will be called +1 more time each time it's called).
                   
                    tbox.TextChanged -= TextBoxChanged;
                    tbox.TextChanged += TextBoxChanged;
    
                }
    
            }
    
            private void TextBoxChanged(object sender, EventArgs e)
            {
                
                // try catch is helpful in a winforms program 'cos otherwise program might just stop.
                // http://stackoverflow.com/questions/1583351/silent-failures-in-c-seemingly-unhandled-exceptions-that-does-not-crash-the-pr
    
                try
                {
                    int colindex = dataGridView1.CurrentCell.ColumnIndex;
    
                    Graphics agraphics = this.CreateGraphics();
    
                    SizeF headerTextSize = agraphics.MeasureString(dataGridView1.Columns[colindex].HeaderText, dataGridView1.EditingControl.Font);
    
                    // sometimes it goes black and this link here says to use editing control http://stackoverflow.com/questions/3207777/datagridview-cell-turns-black-when-accessing-editedformattedvalue
    
    
                    SizeF curCellTextSize = agraphics.MeasureString(dataGridView1.CurrentCell.EditedFormattedValue.ToString(), dataGridView1.EditingControl.Font);
                    //SizeF curCellTextSize = agraphics.MeasureString(dataGridView1.CurrentCell.GetEditedFormattedValue.ToString(), dataGridView1.EditingControl.Font);
                    int curCellTextSize_i = (int)Math.Round(curCellTextSize.Width, 0);
    
                    int headerCellSize = dataGridView1.Columns[colindex].Width;
    
                    textBox2.Text = headerTextSize.Width.ToString();
                    textBox3.Text = headerCellSize.ToString();
    
                    // find biggest existing one
                    int maxcelltextincol = (int)Math.Round(headerTextSize.Width,0);
                    // the max size, at least for the header, includes a bit of padding.. 
                    maxcelltextincol += 20;
                    int tempcelllength=0;
                    for(int i=0; i<dataGridView1.Rows.Count;i++) {
                        if (dataGridView1.Rows[i].Cells[colindex].Value == null) dataGridView1.Rows[i].Cells[colindex].Value = "";
    
                        tempcelllength = (int)Math.Round(agraphics.MeasureString(dataGridView1.Rows[i].Cells[colindex].Value.ToString(), dataGridView1.EditingControl.Font).Width, 0);
    
                        if (tempcelllength > maxcelltextincol) maxcelltextincol = tempcelllength;       
                    }
    
             
                //    textBox2.Text = "PRE curCellTextSize_i=" + curCellTextSize_i + " " + "dgvw=" + dataGridView1.Columns[colindex].Width.ToString() + " max=" + maxcelltextincol.ToString() +  " prevstringlength=";
    
                    string txtinwhatiamediting = dataGridView1.CurrentCell.EditedFormattedValue.ToString();
    
                    SizeF sizelengthoftxtinwhatiamediting = agraphics.MeasureString(txtinwhatiamediting, dataGridView1.Font); //intermediate
                    int lengthoftxtinwhatiamediting=(int)Math.Round(sizelengthoftxtinwhatiamediting.Width,0);
    
                    //if(lengthoftxtinwhatiamediting>maxcelltextincol) 
                    int amountovermax = lengthoftxtinwhatiamediting - maxcelltextincol;    
    
                    int oldcolwidth = dataGridView1.Columns[colindex].Width;
                    if (amountovermax < 0) { dataGridView1.Columns[colindex].Width = maxcelltextincol; return; }
    
                    
                    dataGridView1.Columns[colindex].Width = maxcelltextincol + amountovermax;
                    int newcolwidth = dataGridView1.Columns[colindex].Width;
                       //dataGridView1.Width += (int)Math.Round((double)amountovermax,0);
                    dataGridView1.Width += newcolwidth - oldcolwidth;
                    this.Width += newcolwidth - oldcolwidth;
                    //   textBox2.Text = "curCellTextSize_i=" + curCellTextSize_i + " " + "dgvw=" + dataGridView1.Columns[colindex].Width.ToString() + " max=" + maxcellincol.ToString();
    
                    if (curCellTextSize_i > maxcelltextincol) maxcelltextincol = curCellTextSize_i;
    
                      // textBox5.Text= "POST curCellTextSize_i=" + curCellTextSize_i + " " + "dgvw=" + dataGridView1.Columns[colindex].Width.ToString() + " max=" + maxcelltextincol.ToString() + "prevstring=" + prevString + " prevstringlength=" + prevtextsize + " diff=" + diff;
                     //  textBox5.Text = "POST curCellTextSize_i=" + curCellTextSize_i + " " + "dgvw=" + dataGridView1.Columns[colindex].Width.ToString() + " max=" + maxcelltextincol.ToString() + " diff=" + amountovermax;
                   
                
                }
                catch (Exception ee) { MessageBox.Show(ee.ToString()); }                                
            }
        
            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    //dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.Font = new System.Drawing.Font("David", 30.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    dataGridView1.Rows.Add(1);
                    
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;                
                    
                    Graphics g = this.CreateGraphics(); // should be in a using.
    
                    Font fontA = new System.Drawing.Font("David", 30.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    
                    SizeF headerSize = g.MeasureString(dataGridView1.Columns[0].HeaderText, fontA);
    
                    int totalcolwidth = dataGridView1.RowHeadersWidth + 40; // about 40+70
                    //MessageBox.Show(totalcolwidth.ToString());
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        totalcolwidth += dataGridView1.Columns[i].Width;
    
                  //  MessageBox.Show(totalcolwidth.ToString());
                  //  MessageBox.Show(dataGridView1.Width.ToString());
                    int diff = totalcolwidth - dataGridView1.Width;
                    dataGridView1.Width = totalcolwidth;
                  //  MessageBox.Show(dataGridView1.Width.ToString());
                    this.Width += diff;
    
                }
                catch (Exception exc)
                {
                    MessageBox.Show("exception ");
                    MessageBox.Show(exc.ToString());
                }
            }
    
    
        }
    }
