            for (int i = 0; i < teams.Count - 1; i++)
            {
                DataRow row = dvp_dt.NewRow();
                var aux = i / 30;
                row["Team"] = (teams[i].InnerText);
                row["Points"] = (points[i].InnerText);
                row["Position"] = (positions_aux[aux]);
               // Console.WriteLine(teams[i].InnerText + ' ' + points[i].InnerText + ' ' + positions_aux[aux]);
            }
            dataGridView2.DataSource = null;        
            dataGridView2.DataSource = dvp_dt;
