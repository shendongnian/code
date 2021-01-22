     DataView view = new DataView(dt);
     view.RowFilter = string.Format("VOCHID='" + SingleVocheridSale + "'");
     dataGridview1.DataSource = view;
     object sumObject;
     sumObject = DtAllSales.Compute("Sum(NETAMT)", view.RowFilter);
     lable1.Text = sumObject.ToString();
