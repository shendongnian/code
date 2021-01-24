        List<int> tableauIndex = new List<int>();
            if (text == "")
            {
                lblTexte.Text = "";
                lblCompteur.Text = "";
                for (int i = 0; i < dgv.Rows.Count - 1; i++)
                {
                    dgv.Rows[i].Selected = false;
                }
                return;
            }
            if (dgv.RowCount < 1)
            {
                return;
            }
            else
            {
                text = text.ToUpper();
                lblTexte.Text = "Champ répondant au critère: ";
                tbx.SelectionStart = text.Length;
                tbx.Text = text;
                BindingList<EnregCommente> bl = (BindingList<EnregCommente>)dgv.DataSource;
                var sortedListInstance = from EnregCommente enr in bl
                                         where(enr.cle.Contains(text))
                                         select enr;
                foreach (EnregCommente enr in sortedListInstance)
                {
                    Console.WriteLine(enr.cle);
                }
                foreach(DataGridViewRow r in dgv.Rows)
                {
                    foreach(EnregCommente enr in sortedListInstance)
                    {
                        if (r.Cells[0].Value.ToString() == enr.cle)
                        {
                            tableauIndex.Add(r.Index);
                        }
                    }
                }
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (tableauIndex.Contains(row.Index))
                    {
                        dgv.Rows[row.Index].Selected = true;
                    }
                    else
                    {
                        dgv.Rows[row.Index].Selected = false;
                    }
                }
                foreach (int i in tableauIndex)
                {
                    dgv.Rows[i].Selected = true;
                }
            }
            if (dgv.SelectedRows.Count != 0)
            {
                dgv.FirstDisplayedScrollingRowIndex = dgv.SelectedRows[0].Index;
            }
            if (dgv.SelectedRows.Count == 0 && text == "")
            {
                lblCompteur.Text = "";
            }
            else
            {
                lblCompteur.Text = dgv.SelectedRows.Count.ToString();
            }
