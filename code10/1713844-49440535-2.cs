				private void button1_Click(object sender, EventArgs e)
				{          
					foreach (DataGridViewRow row in dataGridView1.Rows)
					{               
						row.DefaultCellStyle.BackColor = Color.White;
						if (row?.Cells["First Name"]?.Value?.ToString().Trim() == "john")
						{                   
							row.DefaultCellStyle.BackColor = Color.Red;
						}
					}
				}
