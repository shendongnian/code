    well thanks for your stupid answer i solved  it my self here is the solution
    private void dataGridView4_Paint(object sender, PaintEventArgs e)
            {
                var startDate = dateTimePicker2.Value.Date;
                var endDate = dateTimePicker1.Value.Date;
                List<string> weeks = new List<string>();
                List<string> dates = new List<string>();
                while (startDate <= endDate)
                {
                    weeks.Add(startDate.DayOfWeek.ToString());
                    dates.Add(startDate.Date.ToString());
                    startDate = startDate.AddDays(1);
    
                }
                for (int j = 0; j < (weeks.Count() * 3); j += 3)
                {
                    Rectangle r1 = this.dataGridView4.GetCellDisplayRectangle(j, -1, true);
                    int w2 = this.dataGridView4.GetCellDisplayRectangle(j + 1, -1, true).Width;
                    r1.X += 1;
                    r1.Y += 1;
                    r1.Width = r1.Width * 3 - 2;
                    r1.Height = r1.Height / 2 - 2;
                    e.Graphics.FillRectangle(new SolidBrush(this.dataGridView4.ColumnHeadersDefaultCellStyle.BackColor), r1);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
    
                    e.Graphics.DrawString(dates[j / 3]+"\n"+weeks[j / 3],
                    this.dataGridView4.ColumnHeadersDefaultCellStyle.Font,
                    new SolidBrush(this.dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor),
                    r1,
                        format);
                }
            }
