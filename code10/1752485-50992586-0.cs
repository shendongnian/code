    private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                WitsStatusDBDataSet.TestCaseRow row = null;
                this.Validate();
                
                int currentPosition = this.witsStatusDBDataSet.TestCase.Rows.Count - 1;
                if(currentPosition == -1)
                {
                    row = AddRowToDataTable(testCase: witsStatusDBDataSet.TestCase);
                }
                if (row == null)
                {
                    currentPosition = this.witsStatusDBDataSet.TestCase.Rows.Count - 1;
                }
                row.AcceptChanges();
                witsStatusDBDataSet.TestCase.AcceptChanges();
                this.testCaseBindingSource.EndEdit();
                
                testCaseTableAdapter.Update(row);
                testCaseTableAdapter.InsertCase(row.Title, row.IsAutomated, row.Description, row.State, row.Area, row.Iteration, row.Priority,
                    row.Severity, row.Owner, row.CreatedDate, row.ModifiedDate, row.TFS_Case_ID, row.TFSInstance);
                WitsStatusDBEntry.WitsStatusDBDataSetTableAdapters.TableAdapterManager manager = new TableAdapterManager();
                manager.Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=WitsStatusDB;Integrated Security=True");
                manager.UpdateAll(witsStatusDBDataSet);
                SysTimer = new System.Timers.Timer(2500);
                statusLabel1.Text = "Updated successfully.";
                SysTimer.Start();
            }
            catch(Exception exc)
            {
                string msg = exc.Message + " : " + exc.StackTrace;
                Clipboard.SetText(msg);
                MessageBox.Show(msg);
            }
        }
