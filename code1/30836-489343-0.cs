    public static ArrayList GetCategory(SPWeb web)
    {
        ArrayList result = new ArrayList();
        /*            <?xml version="1.0" encoding="utf-16"?>
        <Field ID="{6DF9BD52-550E-4a30-BC31-A4366832A87D}" Type="Choice" Group="_Hidden" Name="Category" DisplayName="Category" SourceID="http://schemas.microsoft.com/sharepoint/v3" StaticName="Category">
          <CHOICES>
            <CHOICE>(1) Category1</CHOICE>
            <CHOICE>(2) Category2</CHOICE>
            <CHOICE>(3) Category3</CHOICE>
          </CHOICES>
          <Default>(2) Category2</Default>
        </Field>*/
        try
        {
            SPField catField = web.Fields[new Guid("6DF9BD52-550E-4a30-BC31-A4366832A87D")];
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(catField.SchemaXml);
            XmlNodeList Choices = Doc.SelectNodes("Field/CHOICES/CHOICE");
            foreach (XmlNode Choice in Choices)
            {
                result.Add(Choice.InnerText);
            }
        }
        catch (Exception ex)
        {
            result.Add("Failed: " + ex.Message);
        }
        return result;
    }
