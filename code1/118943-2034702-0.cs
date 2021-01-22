            int VertAmount = 0;
            VertAmount = dataGridView1.Rows.Count;
            txtLog.Text += "Amount of Rows: " + VertAmount + "\r\n";
            // *******************************************************************************************//
            // Calculate and populate X1 * Y2 in a list
            int tel1 = 0;
            for (int i = 0; i < VertAmount-1; i++)
            {
                tel1++;
                double x1x = Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString());
                double y2y = Convert.ToDouble(dataGridView1.Rows[i+1].Cells[2].Value.ToString());
                x1y2lst.Add(x1x * y2y);
            }
            // Calculate the last with the first value
            double xLastx = Convert.ToDouble(dataGridView1.Rows[tel1].Cells[1].Value.ToString());
            double yFirsty = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value.ToString());
            x1y2lst.Add(xLastx * yFirsty);
            // *******************************************************************************************//
            // Calculate and populate Y1 * X2 in a list
            int tel2 = 0;
            for (int i = 0; i < VertAmount - 1; i++)
            {
                tel2++;
                double y1y = Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                double x2x = Convert.ToDouble(dataGridView1.Rows[i + 1].Cells[1].Value.ToString());
                y1x2lst.Add(y1y * x2x);
            }
            // Calculate the last with the first value
            double yLasty = Convert.ToDouble(dataGridView1.Rows[tel2].Cells[2].Value.ToString());
            double xFirstx = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString());
            y1x2lst.Add(yLasty * xFirstx);
            // Subract List1 values from List2 values
            for (int k = 0; k < x1y2lst.Count; k++)
            {
                x1y2lstMinusy1x2lst.Add(x1y2lst[k] - y1x2lst[k]);
            }
            double resultant = 0;
            double area = 0;
            // Add all answers from previous to a result
            for (int l = 0; l < x1y2lstMinusy1x2lst.Count; l++)
            {
                resultant += x1y2lstMinusy1x2lst[l];
            }
            // Area = Result from steps above devided by 2
            area = Math.Abs(resultant / 2);
