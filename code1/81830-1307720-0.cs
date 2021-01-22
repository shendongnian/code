    private void cmdSaveToExcel_Click(object sender, EventArgs e)
            {
                saveFileDialog1.Filter = "Excel (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = saveFileDialog1.FileName;               
                }
                // create the DataGrid and perform the databinding
                System.Web.UI.WebControls.DataGrid grid = new System.Web.UI.WebControls.DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                if (connDBs != null && rtxtCode.Text != "")
                {
                    DataTable dt;
                    dt = connDBs.userQuery(rtxtCode.Text); // getting a table with one column of the databases names
                    //grdData.DataSource = dt;
                    grid.DataSource = dt;
                    // grid.DataMember = data.Stats.TableName;
                    grid.DataBind();
                    // render the DataGrid control to a file
                    using (StreamWriter sw = new StreamWriter(txtPath.Text))
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            grid.RenderControl(hw);
                        }
                    }
                    MessageBox.Show("The excel file was created successfully");
                }
                else
                {
                    MessageBox.Show("Missing connection or query");
                }
            }
