                if (cmb_mode_of_service.SelectedIndex > 0 && cmb_term_of_service.SelectedIndex > 0)
                {
                    if (cmb_mode_of_service.SelectedItem.ToString() == "Single Service/Installation" || cmb_term_of_service.SelectedItem.ToString() == "Single Time")
                    {
                        int c2 = 1;
                        char c1 = 'A';
                        DataRow dr = dt.NewRow();
                        dr["SN"] = c2++;
                        dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                        dr["servicedate"] = service_start_date.Text;
                        dr["servicestatus"] = "Pending";
                        dr["serviceexcutive"] = "Not Alowed";
                        dt.Rows.Add(dr);
                        dataGridView1.DataSource = dt;
                        txtexpirydate.Text = (Convert.ToDateTime(service_start_date.Text).AddDays(1)).ToString();
                    }
                    else
                    {
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
                            txtexpirydate.Text = Enddate.ToString();
                            char c1 = 'A';
                            int c2 = 1;
                            for (var dt1 = currentdate.AddDays(7); dt1 <= Enddate; dt1 = dt1.AddDays(7))
                            {
                                DataRow dr = dt.NewRow();
                                dr["SN"] = c2++;
                                dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                                dr["servicedate"] = dt1.ToString();
                                dr["servicestatus"] = "Pending";
                                dr["serviceexcutive"] = "Not Alowed";
                                //txtexpirydate.Text = dt1.ToString();
                                dt.Rows.Add(dr);
                            }
                            dataGridView1.DataSource = dt;
                        }
                        if (cmb_mode_of_service.SelectedItem.ToString() == "Fortnight Service")
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
                            txtexpirydate.Text = Enddate.ToString();
                            char c1 = 'A';
                            int c2 = 1;
                            for (var dt1 = currentdate.AddDays(15); dt1 <= Enddate; dt1 = dt1.AddDays(15))
                            {
                                DataRow dr = dt.NewRow();
                                dr["SN"] = c2++;
                                dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                                dr["servicedate"] = dt1.ToString();
                                dr["servicestatus"] = "Pending";
                                dr["serviceexcutive"] = "Not Alowed";
                                //  txtexpirydate.Text = dt1.ToString();
                                dt.Rows.Add(dr);
                            }
                            dataGridView1.DataSource = dt;
                        }
                        if (cmb_mode_of_service.SelectedItem.ToString() == "Monthly Service")
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
                            txtexpirydate.Text = Enddate.ToString();
                            char c1 = 'A';
                            int c2 = 1;
                            for (var dt1 = currentdate.AddDays(30); dt1 <= Enddate; dt1 = dt1.AddDays(30))
                            {
                                DataRow dr = dt.NewRow();
                                dr["SN"] = c2++;
                                dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                                dr["servicedate"] = dt1.ToString();
                                dr["servicestatus"] = "Pending";
                                dr["serviceexcutive"] = "Not Alowed";
                                // txtexpirydate.Text = dt1.ToString();
                                dt.Rows.Add(dr);
                            }
                            dataGridView1.DataSource = dt;
                        }
                        if (cmb_mode_of_service.SelectedItem.ToString() == "Trimister Service")
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
                            txtexpirydate.Text = Enddate.ToString();
                            char c1 = 'A';
                            int c2 = 1;
                            for (var dt1 = currentdate.AddDays(90); dt1 <= Enddate; dt1 = dt1.AddDays(90))
                            {
                                DataRow dr = dt.NewRow();
                                dr["SN"] = c2++;
                                dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                                dr["servicedate"] = dt1.ToString();
                                dr["servicestatus"] = "Pending";
                                dr["serviceexcutive"] = "Not Alowed";
                                // txtexpirydate.Text = dt1.ToString();
                                dt.Rows.Add(dr);
                            }
                            dataGridView1.DataSource = dt;
                        }
                        if (cmb_mode_of_service.SelectedItem.ToString() == "Half Yearly Service")
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
                            txtexpirydate.Text = Enddate.ToString();
                            char c1 = 'A';
                            int c2 = 1;
                            for (var dt1 = currentdate.AddDays(180); dt1 <= Enddate; dt1 = dt1.AddDays(180))
                            {
                                DataRow dr = dt.NewRow();
                                dr["SN"] = c2++;
                                dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                                dr["servicedate"] = dt1.ToString();
                                dr["servicestatus"] = "Pending";
                                dr["serviceexcutive"] = "Not Alowed";
                                //  txtexpirydate.Text = dt1.ToString();
                                dt.Rows.Add(dr);
                            }
                            dataGridView1.DataSource = dt;
                        }
                        if (cmb_mode_of_service.SelectedItem.ToString() == "Yearly Service")
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
                            txtexpirydate.Text = Enddate.ToString();
                            char c1 = 'A';
                            int c2 = 1;
                            for (var dt1 = currentdate.AddDays(365); dt1 <= Enddate; dt1 = dt1.AddDays(365))
                            {
                                DataRow dr = dt.NewRow();
                                dr["SN"] = c2++;
                                dr["serviceid"] = txt_service_id.Text + "-" + c1++;
                                dr["servicedate"] = dt1.ToString();
                                dr["servicestatus"] = "Pending";
                                dr["serviceexcutive"] = "Not Alowed";
                                //txtexpirydate.Text = dt1.ToString();
                                dt.Rows.Add(dr);
                            }
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
