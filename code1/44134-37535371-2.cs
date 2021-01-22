    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace datagridviewexpandcelldynamically_with_second_dgv
    {
        public partial class Form1 : Form
        {
            DataGridView dgvtest = new DataGridView();
            //  DataGridView dgvtest;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                    dataGridView1.AllowUserToAddRows = false;
                    dgvtest.AllowUserToAddRows = false;
    
                    dataGridView1.CellBeginEdit += (object ssender, DataGridViewCellCancelEventArgs ee) =>
                    {
                        //keep column width as it is for now but just change autosize to none so will be able to manually increase it
                        int origColumnWidth = dataGridView1.Columns[ee.ColumnIndex].Width;
                        dataGridView1.Columns[ee.ColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                        dataGridView1.Columns[ee.ColumnIndex].Width = origColumnWidth;
                    };
    
                    dataGridView1.CellEndEdit += (object sssender, DataGridViewCellEventArgs eee) =>
                    {
                        dataGridView1.Columns[eee.ColumnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    };
    
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
                    dgvtest.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvtest.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    
                   
                    dgvtest.Columns.Add("Column1", "Column1");
                    dgvtest.Columns.Add("Column2", "Column2");
    
                    dgvtest.Rows.Add(1);
                    dataGridView1.Rows.Add(1);
    
                    /*
                    Form newfrm = new Form();
                    newfrm.Show();
                    newfrm.Controls.Add(dgvtest);
                    dgvtest.Show();
                    */
                    //dgvtest.Rows[0].Cells[0].Value = "abc";
    
                
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
                    //not KeyDown 'cos the character has not appeared yet in the box. and one would have to check what it was as a parameter, and if it's a backdelete then go back one.. and also forward delete isn't coutned as a keydown.
                    //not KeyUp 'cos while yeah the character has at least appeared, there's a delay so if you hold backdelete then only after releasing it will it trigger the procedure, and updating the width of the cell then is a bit late.
                    //not KeyPress 'cos has issues of keyup. 
    
                }
    
            }
    
    
            private void TextBoxChanged(object sender, EventArgs e)
            {
    
    
                int colindex = dataGridView1.CurrentCell.ColumnIndex;
    
    
                int oldcolwidth = dataGridView1.CurrentCell.Size.Width;
                //string stredit=dataGridView1.CurrentCell.EditedFormattedValue.ToString();
                string stredit=dataGridView1.EditingControl.Text;
                dgvtest.Rows[0].Cells[0].Value = stredit;
    
                int newcolwidth = dgvtest.Rows[0].Cells[0].Size.Width;
    
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
    
                // txtdesc.Text = "";
                txtdesc.Text += "newcolwidth=" + newcolwidth + "\r\n";
                txtdesc.Text += "maxcellincol=" + maxcellincol + "\r\n";
    
    
                //if (newcolwidth < maxcellincol)  != even if = then fine.
     
                dataGridView1.Columns[colindex].Width = newcolwidth;
                dataGridView1.Width += diffcol;
    
            } 
        }
    
    
    }
