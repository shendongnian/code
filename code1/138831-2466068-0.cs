    private void Form1_VisibleChanged(object sender, EventArgs e)
            {
                if (this.Visible)
                {
                    this.Invoke(new EventHandler(delegate
                    {
                        if (NVRDataGridView.ColumnCount > 0)
                        {
                            NVRDataGridView.Columns[0].Width = 20;
                        }
                    }));
                }
            }
