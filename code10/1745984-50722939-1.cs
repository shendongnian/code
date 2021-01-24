     string[] format = new string[] { "dd/MM/yyyy HH:mm:ss" };
                                DateTime datetime;
                                if (DateTime.TryParseExact(data.Rows[i][z].ToString(), format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.NoCurrentDateDefault, out datetime))
                                    dataGridView1.Rows[i + 2].Cells[z].Value = datetime.ToString("hh:MM:ss");
                                else
                                    dataGridView1.Rows[i + 2].Cells[z].Value = data.Rows[i][z];
