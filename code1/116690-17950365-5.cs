    //In Code In Front...
    Table.DataGridView{float:left; width:100%;}
    Table.DataGridView tr{}
    Table.DataGridView th{ background-color:Gray; font-weight:bold; color:White;}
    Table.DataGridView td{ background-color:White; color:Black; font-weight:normal;}
    <asp:GridView ID="DataGridView" runat="server" CssClass="DataGridView" GridLines="Both" Visible="false" />
    //In Code Behind...
    XmlNode myXmlNodeObject = myXmlDocService.GetData(_xmlDataString);
        //Bind To GridView
		//Create a DataSet To Bind To
		DataSet ds = new DataSet();
		ds.Tables.Add("XmlDataSet");
		//Get Column Names as String Array
		XmlDocument XMLDoc = new XmlDocument();
		XMLDoc.LoadXml("<result>" +myXmlNodeObject.ChildNodes.Item(0).ChildNodes.Item(2).ParentNode.InnerXml + "</result>"); //Get Row/Columns
		int colCount = myXmlNodeObject.ChildNodes.Item(0).ChildNodes.Item(2).SelectNodes("column").Count;
		string[] ColumnNameArray = new string[colCount];
		int iterator = 0;
		foreach(XmlNode node in myXmlNodeObject.ChildNodes.Item(0).ChildNodes.Item(2).SelectNodes("column"))
		{
			ColumnNameArray.SetValue(node.Attributes["name"].Value ,iterator);
			ds.Tables["XmlDataSet"].Columns.Add(node.Attributes["name"].Value); //Create individual columns in the dataset
			iterator++;
		}
		//Get Data Row By Row to populate the DataSet.Rows
		foreach(XmlNode RowNode in XMLDoc.ChildNodes.Item(0).SelectNodes("row"))
		{
			string[] rowArray = new string[colCount]; 
			int iterator2 = 0;
			foreach(XmlNode ColumnNode in RowNode.ChildNodes)
			{
				rowArray.SetValue(ColumnNode.InnerText, iterator2);
				iterator2++;
			}
			ds.Tables["XmlDataSet"].Rows.Add(rowArray);
		}
		DataGridView.DataSource = ds.Tables["XmlDataSet"];
		DataGridView.DataKeyNames = ColumnNameArray;
		DataGridView.DataBind();
		DataGridView.Visible = true;
	
