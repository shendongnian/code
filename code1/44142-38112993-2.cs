    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
     
    
    namespace dgveditresize
    {
        public partial class Form1 : Form
        {
            
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //DGVprocs.dgv = dataGridView1;
                dataGridView1.AllowUserToAddRows = false;
    
                autoshrinkwholedgv();
    
                //DGVprocs.autoshrink_off_wholedgv__preservewidths(); not necessary
                dataGridView1.Rows.Add(5);
                //dataGridView1.CellBeginEdit += OnCellBeginEditExpandCol;
    
                 dataGridView1.EditingControlShowing += DataGridView1_EditingControlShowing;
    
              //  MessageBox.Show(dataGridView1.Columns[1].Width.ToString());
            }
    
           
            private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
    
               // MessageBox.Show(dataGridView1.Columns[1].Width.ToString());
    
    
    
                // http://stackoverflow.com/questions/37505883/how-can-i-dynamically-detect-the-characters-in-a-datagridview-cell-execute-co
          
                //if(DGVprocs.isshrinkon()==false) { MessageBox.Show("err ")}
    
                if (e.Control is TextBox)
                {
                    var tbox = (e.Control as TextBox);
    
                    // De-register the event FIRST so as to avoid multiple assignments (necessary to do this or the event
                    // will be called +1 more time each time it's called).
    
                    tbox.TextChanged -= A_Cell_TextChanged;
                    tbox.TextChanged += A_Cell_TextChanged;
                }
    
              
    
            }
    
            private void A_Cell_TextChanged(object sender, EventArgs e)
            {
                
                dataGridView1.Rows.Add(1);
    
                //MessageBox.Show(dataGridView1.Rows.Count+" rows");
    
                int colindex = dataGridView1.CurrentCell.ColumnIndex;
    
    
                int oldcolwidth = dataGridView1.CurrentCell.Size.Width;
                //string stredit=dataGridView1.CurrentCell.EditedFormattedValue.ToString();
                string stredit = dataGridView1.EditingControl.Text;
    
                //dgvtest.Rows[0].Cells[0].Value = stredit;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dataGridView1.CurrentCell.ColumnIndex].Value = stredit;
                //MessageBox.Show(dataGridView1.Rows.Count + " rows");
                //int newcolwidth = dgvtest.Rows[0].Cells[0].Size.Width;
    
                //autoshrinkcurrentcol(); // WORSE   (1)  WW
                autoshrinkwholedgv(); //added BETTER (2)  XX
                int newcolwidth = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dataGridView1.CurrentCell.ColumnIndex].Size.Width;
                autoshrinkoff_wholedgv_preservewidths(); //added BETTER (3) YY
               // autoshrink_off_currentcol_preservewidth(); // WORSE (4)  ZZ
                 /*               
                 WAS ERROR WITH THIS ONE..
                 IF YOU TYPE IN THE FIRST CELL THEN HIT DOWN ARROW TWICE
                 THEN TYPE THEN IT GOES BLACK
                 BUT PROBLEM RESOLVED  SINCE USING 2,3 RATHER THAN 1,4                    
                  */
                // doing either  1,4  or 2,3
                // no comparison
                // 1,4 causes blackness.
                // 2,3 and it works
                // all of them is just same as 2,3 not surprising.
                // but funny that 1,4 causes blackness.
    
    
                //MessageBox.Show("removing row");
                 
                if(dataGridView1.AllowUserToAddRows) { MessageBox.Show("programmer msg- issue in 'cell's textchanged method', allowusertoaddrows must be false otherwise an exception is thrown by the next line dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);"); Application.Exit(); }
                    // requires user not add row set to true.
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
    
                //MessageBox.Show(dataGridView1.Rows.Count + " rows");
    
                int headercellsize = dataGridView1.Columns[colindex].HeaderCell.Size.Width;
    
                // find biggest existing one
                int maxcellincol = headercellsize;
    
                int tempcelllength = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[colindex].Value == null) dataGridView1.Rows[i].Cells[colindex].Value = "";
    
                    //length of all others but not current.
                    tempcelllength = dataGridView1.Rows[i].Cells[colindex].Size.Width;
    
                    if (tempcelllength > maxcellincol) maxcellincol = tempcelllength;
                }
    
    
    
                int diffcol = newcolwidth - oldcolwidth;
    
                // new isn't an ideal name.. 'cos it's not made new yet.. and 'cos if it's smaller than the max one then we won't make it the new one.. but it will be the new one if it's bigger than the max.
    
                 txtdesc.Text = "";
                txtdesc.Text += "newcolwidth=" + newcolwidth + "\r\n";
                txtdesc.Text += "maxcellincol=" + maxcellincol + "\r\n";
    
    
                //if (newcolwidth < maxcellincol)  != even if = then fine.
    
                // say we move that earlier
                //dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
    
                //DGVprocs.autoshrinkoff_preservecurrentcolwidth();
    
    
                //if (dataGridView1.Columns[colindex].Width == newcolwidth)
                if (oldcolwidth == newcolwidth)
                txtwidthcomp.Text="old width is equal to cur width diff="+diffcol;
                else
                    txtwidthcomp.Text="old width is not equal to cur width diff="+diffcol;
    
                //shrink should never be on while there's an editbox showing.
                //if (diffcol>0) if (DGVprocs.isshrinkon() == true) MessageBox.Show("shrink is on this may be why it's not resizing");
                // when turning autoshrink off a)it should be done after the editbox it will freeze the editbox to the size that it was. b)when it is done it should be done in a preservational way. getting all col sizes beforehand and turning shrink off and setting all cols to that size that they were 
                // DGVprocs.autoshrinkoff();
                // shrink has to be off for the current column.. doesn't matter about the rest of it.
                // if(diffcol>0) if(DGVprocs.isshrinkoncurrentcol()==true) MessageBox.Show("shrink is on(cur col) this may be why it's not resizing");
    
    
    
                dataGridView1.Columns[colindex].Width = newcolwidth;
                dataGridView1.Width += diffcol;
    
                
                // i think autoshrink while the editbox is showing is wrong.
                // you need to autoshrink it to size of editbox.
    //            DGVprocs.autoshrink();
             
                
            }
    
    
            public void autoshrinkwholedgv()
            {
    
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
                return;
            }
    
            public void autoshrinkcurrentcol()
            {
    
                dataGridView1.Columns[getcurrentcol()].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
    
                //this may be optional.
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    
                // DGVprocs.dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
                return;
            }
    
            public int getcurrentcol()
            {
                if (dataGridView1.CurrentCell == null) { MessageBox.Show("Programmer msg - getcurrentcol() error, current cell not selected"); Application.Exit(); }
                if (dataGridView1.CurrentCell.Value == null) dataGridView1.CurrentCell.Value = "";
    
                return dataGridView1.CurrentCell.ColumnIndex;
            }
    
            public void autoshrink_off_currentcol_preservewidth()
            {
                int w =  dataGridView1.Columns[getcurrentcol()].Width;
                dataGridView1.Columns[getcurrentcol()].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dataGridView1.Columns[getcurrentcol()].Width = w;
            }
    
            public void autoshrinkoff_wholedgv_preservewidths()
            {
                // deal with the 73,100 bug.. whereby if you ave autoresize on immediately, then a DGV with Column1 Colum2, Column3 e.t.c. has width of 73. But then when turning autoresize off it goes to 100. 
    
                int[] colsizes = new int[dataGridView1.Columns.Count];
    
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    colsizes[i] = dataGridView1.Columns[i].Width;
    
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
    
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    dataGridView1.Columns[i].Width = colsizes[i];
    
    
                return;
            }
    
        }
    
    
    }
