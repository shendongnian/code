     private void Display_Data(object sender, EventArgs e)
     {
          try
          {
              XmlReader xmlFile ;
              xmlFile = XmlReader.Create("Product.xml", new XmlReaderSettings());
              DataSet ds = new DataSet();
              ds.ReadXml(xmlFile);
              dataGridView1.DataSource = ds.Tables[0];
          }
          catch (Exception ex)
          {
              MessageBox.Show (ex.ToString());
          } 
      }
