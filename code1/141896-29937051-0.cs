    if (cmb_mode_of_service.SelectedItem.ToString() == "Weekly Service")
                {
                    int year = 0;
                    if (cmb_term_of_service.SelectedItem.ToString() == "One Year")
                    {
                        year = 1;
                    }
                    if (cmb_term_of_service.SelectedItem.ToString() == "Two Year")
                    {
                        year = 2;
                    }
                    if (cmb_term_of_service.SelectedItem.ToString() == "three year")
                    {
                        year = 3;
                    }
                    DateTime currentdate = Convert.ToDateTime(service_start_date.Text);
                    DateTime Enddate = currentdate.AddYears(+year);
                    char c1 = 'A';
                    int c2 = 1;
                    for (var dt1 = currentdate; dt1 <= Enddate; dt1 = dt1.AddDays(7))
                    {
                        DataRow dr = dt.NewRow();
                        dr["SN"] = c2++;
                        dr["serviceid"] = "S4-" + c1++;
                        dr["servicedate"] = dt1.ToString();
                        dr["servicestatus"] = "Pending";
                        dr["serviceexcutive"] = "Not Alowed";
                        dt.Rows.Add(dr);
                    }
                    dataGridView1.DataSource = dt;
                }
