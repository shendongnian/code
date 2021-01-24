    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MathWorks.MATLAB.NET.Arrays;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                //create Object from your dll
                mymatrix.Class1 MyObject = new mymatrix.Class1();
    
                //run the method which gets the data and save in a MWArray object
                MWArray MatlabData= MyObject.mymatrix();
    
                //cast the data to MWNumericArray
                MWNumericArray TableValuesMat = (MWNumericArray)MatlabData;
    
                // now cast to a double array   
                double[,] TableValues = (double[,])TableValuesMat.ToArray();
    
                // now convert 2d array to a table in gridview:
                int height = TableValues.GetLength(0);
                int width = TableValues.GetLength(1);
                this.dataGridView1.ColumnCount = width;
                for (int r = 0; r < height; r++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(this.dataGridView1);
    
                    for (int c = 0; c < width; c++)
                    {
                        row.Cells[c].Value = TableValues[r, c];
                    }
    
                    this.dataGridView1.Rows.Add(row);
                }
    
    
            }
        }
    }
