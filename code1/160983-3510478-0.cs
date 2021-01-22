           this.DataGridViewIssue.Rows.Add();//This line will add a new button contol into the grid 
       }
       private void deleteRowButton_Click(object sender, EventArgs e)
       {
           if (this.DataGridViewIssue.SelectedRows.Count > 0 &&
               this.DataGridViewIssue.SelectedRows[0].Index !=
               this.DataGridViewIssue.Rows.Count - 1)
           {
               this.DataGridViewIssue.Rows.RemoveAt(
                   this.DataGridViewIssue.SelectedRows[0].Index);
           }
       }
       private void SetupLayout()
       {
           this.Size = new Size(1055, 800);
           addNewRowButton.Text = "Add Row";
           addNewRowButton.Location = new Point(10, 10);
           addNewRowButton.Click += new EventHandler(addNewRowButton_Click);
           deleteRowButton.Text = "Delete Row";
           deleteRowButton.Location = new Point(100, 10);
           deleteRowButton.Click += new EventHandler(deleteRowButton_Click);
           buttonPanel.Controls.Add(addNewRowButton);
           buttonPanel.Controls.Add(deleteRowButton);
           buttonPanel.Height = 50;
           buttonPanel.Dock = DockStyle.Bottom;
           this.Controls.Add(this.buttonPanel);
       }
