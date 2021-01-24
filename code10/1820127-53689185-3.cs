    try {
        DataTable dt = new DataTable();
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Amount", typeof(string));
        dt.Columns.Add("Date", typeof(string));
        XDocument doc = XDocument.Load(filepath);
        foreach (XElement transaction in doc.Descendants().Where(x => x.Name.LocalName == "Transaction")) {
          dt.Rows.Add(transaction.Element("Name").Value, transaction.Element("Amount").Value, transaction.Element("Date").Value);
        }
        dataGridView1.DataSource = dt;
    }
    catch (Exception ex) {
      MessageBox.Show("Error: " + ex.Message);
    }
