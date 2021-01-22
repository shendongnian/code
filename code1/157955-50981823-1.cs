     DataView view = new DataView(dt);
     view.RowFilter = string.Format("VOCHID='" + SingleVocheridSale + "'");
     dataGridview1.DataSource = view;
     object sumObject;
     sumObject = dt.Compute("Sum(NETAMT)", view.RowFilter);
     lable1.Text = sumObject.ToString();
