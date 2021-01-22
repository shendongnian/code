            DataSet myDS = new DataSet();
            DataTable myTable = new DataTable("item");
            myTable.Columns.Add("id", typeof(string));
            myTable.Columns.Add("name", typeof(string));
            myTable.Columns.Add("name1", typeof(string));
            myTable.Columns.Add("name2", typeof(string));
            myDS.Tables.Add(myTable);
            string xmlData = "<items>  <item>   <id>i1</id>   <name>item1</name>   <subitems>    <name1>subitem1</name1>    <name2>subitem2</name2>   </subitems>  </item>  <item>   <id>i2</id>   <name>item2</name>   <subitems>    <name1>subitem3</name1>    <name2>subitem4</name2>   </subitems></item></items>";
            System.IO.MemoryStream itemsStream = new System.IO.MemoryStream(Encoding.ASCII.GetBytes(xmlData));
            myDS.ReadXml(itemsStream, XmlReadMode.IgnoreSchema);
            foreach (DataRow itemRow in myDS.Tables["item"].Rows)
            {
                MessageBox.Show("column id=" + itemRow["id"]  + " name=" + itemRow["name"]);
                MessageBox.Show(itemRow["name1"].ToString() + " - " + itemRow["name2"].ToString());
            }
