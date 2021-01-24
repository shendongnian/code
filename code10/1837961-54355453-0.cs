    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace AddUser_API
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                /*Makes the request to API for the groups when the form loads. I obviously have a different class that handles this request*/
                Request userClient = new Request();
    
                //endpoint is a GET request
                userClient.endPoint = userClient.endPoint;
                userClient.httpMethod = httpVerb.GET;
    
                string strResponse = string.Empty;
    
                strResponse = userClient.makeRequest();
    
                /*This will put the response into a list then fill the datagridview control with the Web API response*/
    
                List<getUser> grpName = JsonConvert.DeserializeObject<List<getUser>>(strResponse);
    
                dgvUserList.DataSource = grpName;
    //Cosmetics
                    dgvUserList.Columns[0].DefaultCellStyle.Padding = new Padding(0, 0, 28, 0);
                    dgvUserList.Columns[1].DefaultCellStyle.Padding = new Padding(0, 0, 28, 0);   
                }
        
    /* the following key up will allow the user to search as they type in the textbox control*/
            private void txtbxByUsername_KeyUp(object sender, KeyEventArgs e)
            {
                string searchValue = txtbxByUsername.Text.ToLower();
                dgvUserList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                try
                {
                    foreach (DataGridViewRow row in dgvUserList.Rows)
                    {
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            if (row.Cells[i].Value != null && row.Cells[i].Value.ToString().ToLower().Contains(searchValue))
                            {
                                int rowIndex = row.Index;
                                dgvUserList.Rows[rowIndex].Selected = true;
                                break;
                            }
    
                        }
    
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
