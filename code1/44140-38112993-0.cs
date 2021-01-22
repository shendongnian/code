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
                
    
               // DGVprocs.dgv = dataGridView1;
                dataGridView1.AllowUserToAddRows = false;
    
    
                autoshrink();
    
    
    
                dataGridView1.Rows.Add(1);
                //dataGridView1.CellBeginEdit += OnCellBeginEditExpandCol;
    
                dataGridView1.CellBeginEdit += (object senderr, DataGridViewCellCancelEventArgs ee) => { autoshrinkoff_preserve(); };
                dataGridView1.CellEndEdit += (object senderr, DataGridViewCellEventArgs ee)=> { autoshrink(); };
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
    
                int colindex = dataGridView1.CurrentCell.ColumnIndex;
    
    
                int oldcolwidth = dataGridView1.CurrentCell.Size.Width;
                //string stredit=dataGridView1.CurrentCell.EditedFormattedValue.ToString();
                string stredit = dataGridView1.EditingControl.Text;
    
                //dgvtest.Rows[0].Cells[0].Value = stredit;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dataGridView1.CurrentCell.ColumnIndex].Value = stredit;
    
                //int newcolwidth = dgvtest.Rows[0].Cells[0].Size.Width;
    
                autoshrink();
    
                int newcolwidth = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[dataGridView1.CurrentCell.ColumnIndex].Size.Width;
                autoshrinkoff_preserve();
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 1);
    
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
    
              //   txtdesc.Text = "";
              //  txtdesc.Text += "newcolwidth=" + newcolwidth + "\r\n";
              //  txtdesc.Text += "maxcellincol=" + maxcellincol + "\r\n";
    
    
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
                if (diffcol>0) if (isshrinkon() == true) MessageBox.Show("shrink is on this may be why it's not resizing");
               // when turning autoshrink off a)it should be done after the editbox it will freeze the editbox to the size that it was. b)when it is done it should be done in a preservational way. getting all col sizes beforehand and turning shrink off and setting all cols to that size that they were 
                // DGVprocs.autoshrinkoff();
    
    
           
    
                dataGridView1.Columns[colindex].Width = newcolwidth;
                dataGridView1.Width += diffcol;
    
                
                // i think autoshrink while the editbox is showing is wrong.
                // you need to autoshrink it to size of editbox.
    //            DGVprocs.autoshrink();
             
                
            }
    
    
            public void autoshrink()
            {
    
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
                return;
            }
    
            public bool isshrinkon()
            {
                // really they should either both be on or both be off. not tested programs with mixtures. they shouldn't be mixed.
    
                if (dataGridView1.AutoSizeRowsMode == DataGridViewAutoSizeRowsMode.AllCells)
                    if (dataGridView1.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.AllCells)
                        return true;
    
                return false;
            }
    
            public void autoshrinkoff_preserve()
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
     
