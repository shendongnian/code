    void Main()
    {
    	var xml = @"
      <table name=""tbl_user"" entire=""Y"">
         <columns>
            <column name=""user_id"" class=""java.lang.Long"" type-id=""-5"" db-type=""bigint"" />
            <column name=""name"" class=""java.lang.String"" length=""255"" type-id=""12"" db-type=""varchar"" />
            <column name=""surnname"" class=""java.lang.String"" length=""255"" type-id=""12"" db-type=""varchar"" />  
         </columns>
         <row><v>1</v><v> John</v><v>Lennon</v> </row>
         <row><v>2</v><v>Paul</v><v>McCartney</v></row>
         <row><v>3</v><v>George</v><v>Harrison</v></row>
         <row><v>4</v><v>Ringo</v><v>Starr</v></row>
      </table>";
    
    	var serializer = new XmlSerializer(typeof(Table));
    	var table = serializer.Deserialize(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml))) as Table;
    	Console.WriteLine($"{table.Columns.Column.Count} columns");
    	Console.WriteLine($"{table.Row.Count} rows");
        // Output:
        // 3 columns
        // 4 rows
    }
    
    [XmlRoot(ElementName = "column")]
    public class Column
    {
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName = "class")]
    	public string Class { get; set; }
    	[XmlAttribute(AttributeName = "type-id")]
    	public string Typeid { get; set; }
    	[XmlAttribute(AttributeName = "db-type")]
    	public string Dbtype { get; set; }
    	[XmlAttribute(AttributeName = "length")]
    	public string Length { get; set; }
    }
    
    [XmlRoot(ElementName = "columns")]
    public class Columns
    {
    	[XmlElement(ElementName = "column")]
    	public List<Column> Column { get; set; }
    }
    
    [XmlRoot(ElementName = "row")]
    public class Row
    {
    	[XmlElement(ElementName = "v")]
    	public List<string> V { get; set; }
    }
    
    [XmlRoot(ElementName = "table")]
    public class Table
    {
    	[XmlElement(ElementName = "columns")]
    	public Columns Columns { get; set; }
    	[XmlElement(ElementName = "row")]
    	public List<Row> Row { get; set; }
    	[XmlAttribute(AttributeName = "name")]
    	public string Name { get; set; }
    	[XmlAttribute(AttributeName = "entire")]
    	public string Entire { get; set; }
    }
