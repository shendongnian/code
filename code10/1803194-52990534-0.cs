    static void Main(string[] args)
    {
        XSSFWorkbook workbook = new XSSFWorkbook();
        ISheet sheet1 = workbook.CreateSheet("Sheet1");
        POIXMLProperties props = workbook.GetProperties();
        //get the underlying properties (of type NPOI.OpenXmlFormats.CT_ExtendedProperties)
        var underlyingProps = props.ExtendedProperties.GetUnderlyingProperties();
        //now set the properties (excuse the vanity!)
        underlyingProps.Application = "petelids";
        underlyingProps.AppVersion = "1.0";
        FileStream sw = File.Create("test.xlsx");
        workbook.Write(sw);
        sw.Close();
    }
