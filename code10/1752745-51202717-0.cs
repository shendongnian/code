    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using Excel;
    
    namespace test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            DataSet result = new DataSet();
    
            private void button1_Click(object sender, EventArgs e)
            {
                string fileName = "";
                fileName = textBox3.Text;
    
                if (fileName == "")
                {
                    MessageBox.Show("Enter Valid file name");
                    return;
                }
    
                converToCSV(comboBox1.SelectedIndex);
    
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                string Chosen_File = "";
    
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Chosen_File = openFileDialog1.FileName;
                }
                if (Chosen_File == String.Empty)
                {
                    return;
                }
                textBox1.Text = Chosen_File;
    
                getExcelData(textBox1.Text);
                
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                DialogResult result = this.folderBrowserDialog1.ShowDialog();
                string foldername = "";
                if (result == DialogResult.OK)
                {
                    foldername = this.folderBrowserDialog1.SelectedPath;
                }
                
                textBox2.Text = foldername;
            }
    
            private void getExcelData(string file)
            {
    
                if (file.EndsWith(".xlsx"))
                {
                    // Reading from a binary Excel file (format; *.xlsx)
                    FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    result = excelReader.AsDataSet();
                    excelReader.Close();
                }
    
                if (file.EndsWith(".xls"))
                {
                    // Reading from a binary Excel file ('97-2003 format; *.xls)
                    FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read);
                    IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                    result = excelReader.AsDataSet();
                    excelReader.Close();
                }
    
                List<string> items = new List<string>();
                for (int i = 0; i < result.Tables.Count; i++)
                    items.Add(result.Tables[i].TableName.ToString());
                comboBox1.DataSource = items;
    
            }
    
            private void converToCSV(int ind)
            {
                // sheets in excel file becomes tables in dataset
                //result.Tables[0].TableName.ToString(); // to get sheet name (table name)
    
                string a = "";
                int row_no = 0;
    
                while (row_no < result.Tables[ind].Rows.Count)
                {
                    for (int i = 0; i < result.Tables[ind].Columns.Count; i++)
                    {
                        a += result.Tables[ind].Rows[row_no][i].ToString() + ",";
                    }
                    row_no++;
                    a += "\n";
                }
                string output = textBox2.Text + "\\" + textBox3.Text + ".csv";
                StreamWriter csv = new StreamWriter(@output, false);
                csv.Write(a);
                csv.Close();
    
                MessageBox.Show("File converted succussfully");
                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.DataSource = null;
                return;
            }
    
        }
    }
