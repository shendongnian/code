            if (MessageBox.Show("Are you sure you want to delete this record(s)", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    for (int i = dgv_Championnat.RowCount -1; i > -1; i--)
                    {
                        if (Convert.ToBoolean(dgv_Championnat.Rows[i].Cells[0].Value) == true)
                        {
                            Program.set.Tables["Champ"].Rows[i].Delete();
                        }
                    }
                    Program.command = new SqlCommandBuilder(Program.AdapterChampionnat);
                    if (Program.AdapterChampionnat.Update(Program.TableChampionnat) > 0)
                    {
                        MessageBox.Show("Well Deleted");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
