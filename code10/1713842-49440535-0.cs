		        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
				{
				   
					// If the data source raises an exception when a cell value is commited, display an error message.
					if (e.Exception != null && e.Context == DataGridViewDataErrorContexts.Commit)
					{
						var data = dataGridView1[e.ColumnIndex, e.RowIndex].EditedFormattedValue;
						
						MessageBox.Show($"The ID {data} is already present.");
						System.Diagnostics.Trace.WriteLine(e.Exception.Message); //log error
						//The Exception.Message will be e.g.: Column 'ID' is constrained to be unique.  Value 'xx' is already present
						e.ThrowException = false;
					   
					}
				}
