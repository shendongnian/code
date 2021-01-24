    public static Random Rnd = new Random();
    public static string GenerateXlsId()
    {
        //{29BD882A-B741-482B-9067-72CC5D939236}
        string id = string.Empty;
        for (int i = 0; i < 32; i++)
            if (Rnd.NextDouble() < 0.5)
                id += Rnd.Next(0, 10);
            else
                id += (char)Rnd.Next(65, 91);
        id = id.Insert(8, "-");
        id = id.Insert(13, "-");
        id = id.Insert(18, "-");
        id = id.Insert(23, "-");
        return id;
    }
    public static void FixDatabarsAtWorksheet(OfficeOpenXml.ExcelWorksheet eworksheet)
    {
		System.Xml.XmlNodeList databars = eworksheet.WorksheetXml.GetElementsByTagName("dataBar");
		if (databars.Count > 0)
		{
			string conditional_formattings_str = string.Empty;
			for (int i = 0; i < databars.Count; i++)
			{
				string temp_databar_id = GenerateXlsId();
				databars[i].ParentNode.InnerXml += @"<extLst>
			<ext uri=""{B025F937-C7B1-47D3-B67F-A62EFF666E3E}"" xmlns:x14=""http://schemas.microsoft.com/office/spreadsheetml/2009/9/main"">
				<x14:id>{" + temp_databar_id + @"}</x14:id>
			</ext>
		</extLst>";
				//--
				string temp_sqref = databars[i].ParentNode.ParentNode.Attributes["sqref"].Value;
				string left_type = string.Empty;
				string left_val = string.Empty;
				string right_type = string.Empty;
				string right_val = string.Empty;
				string color = string.Empty;
				Color databar_fill_color = Color.Empty;
				Color databar_border_color = Color.Empty;
				for (int j = 0; j < databars[i].ChildNodes.Count; j++)
					if (databars[i].ChildNodes[j].LocalName == "cfvo" && databars[i].ChildNodes[j].Attributes["type"] != null)
					{
						if (string.IsNullOrEmpty(left_type))
							left_type = databars[i].ChildNodes[j].Attributes["type"].Value;
						else if (string.IsNullOrEmpty(right_type))
							right_type = databars[i].ChildNodes[j].Attributes["type"].Value;
						if (databars[i].ChildNodes[j].Attributes["val"] != null)
							if (string.IsNullOrEmpty(left_val))
								left_val = databars[i].ChildNodes[j].Attributes["val"].Value;
							else if (string.IsNullOrEmpty(right_val))
								right_val = databars[i].ChildNodes[j].Attributes["val"].Value;
					}
					else if (databars[i].ChildNodes[j].LocalName == "color")
					{
						color = databars[i].ChildNodes[j].Attributes["rgb"].Value;
						int argb = Int32.Parse(color, System.Globalization.NumberStyles.HexNumber);
						databar_fill_color = Color.FromArgb(argb);
						databar_border_color = Color.FromArgb(255,
							databar_fill_color.R - 50 < 0 ? databar_fill_color.R + 50 : databar_fill_color.R - 50,
							databar_fill_color.G - 50 < 0 ? databar_fill_color.R + 50 : databar_fill_color.G - 50,
							databar_fill_color.B - 50 < 0 ? databar_fill_color.R + 50 : databar_fill_color.B - 50);
					}
				string temp_conditional_formatting_template = @"<x14:conditionalFormatting xmlns:xm=""http://schemas.microsoft.com/office/excel/2006/main"">
			<x14:cfRule type=""dataBar"" id=""{" + temp_databar_id + @"}"">
				<x14:dataBar minLength=""" + (string.IsNullOrEmpty(left_val) ? "0" : left_val) + "\" maxLength=\"" + (string.IsNullOrEmpty(right_val) ? "100" : right_val) + "\" gradient=\"0\" " + (databar_border_color.IsEmpty ? string.Empty : "border = \"1\"") + ">";
				temp_conditional_formatting_template += Environment.NewLine + "<x14:cfvo type=\"" + (left_type.ToLower() == "min" ? "autoMin" : left_type) + "\" />";
				temp_conditional_formatting_template += Environment.NewLine + "<x14:cfvo type=\"" + (right_type.ToLower() == "max" ? "autoMax" : right_type) + "\" />";
				if (!databar_border_color.IsEmpty)
					temp_conditional_formatting_template += Environment.NewLine + "<x14:borderColor rgb=\"" + BitConverter.ToString(new byte[] { databar_border_color.A, databar_border_color.R, databar_border_color.G, databar_border_color.B }).Replace("-", "") + "\" />";
				temp_conditional_formatting_template += Environment.NewLine + @"</x14:dataBar>
			</x14:cfRule>
			<xm:sqref>" + temp_sqref + @"</xm:sqref>
		</x14:conditionalFormatting>";
				conditional_formattings_str += temp_conditional_formatting_template;
			}
			databars[0].ParentNode.ParentNode.ParentNode.InnerXml += @"<extLst>
    <ext uri=""{78C0D931-6437-407d-A8EE-F0AAD7539E65}"" xmlns:x14=""http://schemas.microsoft.com/office/spreadsheetml/2009/9/main"">
	<x14:conditionalFormattings>" + conditional_formattings_str + @" 
    </x14:conditionalFormattings>
    </ext>
    </extLst>";
		}
	}
