    			private void button3_Click(object sender, EventArgs e)
			    {
				try
				{
					OpenFileDialog dlg_im = new OpenFileDialog();
					dlg_im.Filter = "Excel File|*.xls;*.xlsx;*.xlsm";
					//dlg_im.Filter = "Excel File|*.xlsx";
					if (dlg_im.ShowDialog() == DialogResult.OK)
					{
						textBox1.Text = dlg_im.FileName;
						string name = "Sheet1";
						string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox1.Text + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
						OleDbConnection Con = new OleDbConnection(constr);
						OleDbCommand OleConnection = new OleDbCommand("SELECT *FROM [Sheet1$A1:A11]", Con);
						Con.Open();
						OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
						DataTable data = new DataTable();
						sda.Fill(data);
						int i = 0;
						foreach (DataRow dr in data.Rows)
						{
							Console.WriteLine(dr.ItemArray[0]);
							dataGridView1.Rows[i].Cells[2].Value = dr.ItemArray[0];
							i++;
						}
						dataGridView1.ClearSelection();
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.ToString());
				}
			}
