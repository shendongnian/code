    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using System.Collections;
    
    namespace WinAutoComplete
    {
        public partial class Form1 : Form
        {
            AutoCompleteStringCollection ProductList = new
            AutoCompleteStringCollection();
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                //declare connection string
                string cnString = @"Data Source=Your_Server_Name; Initial Catalog=Your_DB_Name;" +
                        "Trusted_Connection = True";
    
                /*use following if you use standard security
                string cnString = @"Data Source=(local);Initial
                Catalog=northwind; Integrated Security=SSPI"; */
                //declare Connection, command and other related objects
    
                SqlConnection conGetData = new SqlConnection(cnString);
                SqlCommand cmdGetData = new SqlCommand();
                SqlDataReader drGetData;
    
                try
                {
                    //open connection
                    conGetData.Open();
                    //prepare connection object to get the data through
                    //reader and populate into dataset
                    cmdGetData.CommandType = CommandType.Text;
                    cmdGetData.Connection = conGetData;
                    cmdGetData.CommandText = "Select ProductName From Products";
                    //read data from command object
    
                    drGetData = cmdGetData.ExecuteReader();
                    if (drGetData.HasRows == true)
                    {
                        while (drGetData.Read())
                            ProductList.Add(drGetData["ProductName"].ToString());
                    }
                    else
    
                        MessageBox.Show("No data found in Products tables");
    
                    //close reader and connection
                    drGetData.Close();
                    conGetData.Close();
                    //set the default pattern to SuggestAppend
                    //comboBoxPattern.SelectedIndex = 1;
                    txtProductID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txtProductID.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txtProductID.AutoCompleteCustomSource = ProductList;
    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //check if connection is still open then attempt to close it
                    if (conGetData.State == ConnectionState.Open)
                    {
                        conGetData.Close();
                    }
                }
            }
    
            private void comboBoxPattern_SelectedIndexChanged(object sender, EventArgs e)
            {
    
                //switch (comboBoxPattern.Text)
                //{
                //    case "Suggest":
                //        txtProductID.AutoCompleteMode = AutoCompleteMode.Suggest;
                //        break;
                //    case "Append":
                //        txtProductID.AutoCompleteMode = AutoCompleteMode.Append;
                //        break;
                //    case "SuggestAppend":
                //        txtProductID.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //        break;
                //}
            }
    
        }
    }
