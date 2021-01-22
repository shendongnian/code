    public static void exportToExcel(DataSet source, string fileName)
    {
            const string endExcelXML = "</Workbook>";
            const string startExcelXML = "<xml version>\r\n<Workbook " +
                     "xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"\r\n" +
                     " xmlns:o=\"urn:schemas-microsoft-com:office:office\"\r\n " +
                     "xmlns:x=\"urn:schemas-    microsoft-com:office:" +
                     "excel\"\r\n xmlns:ss=\"urn:schemas-microsoft-com:" +
                     "office:spreadsheet\">\r\n <Styles>\r\n " +
                     "<Style ss:ID=\"Default\" ss:Name=\"Normal\">\r\n " +
                     "<Alignment ss:Vertical=\"Bottom\"/>\r\n <Borders/>" +
                     "\r\n <Font/>\r\n <Interior/>\r\n <NumberFormat/>" +
                     "\r\n <Protection/>\r\n </Style>\r\n " +
                     "<Style ss:ID=\"BoldColumn\">\r\n <Font " +
                     "x:Family=\"Swiss\" ss:Bold=\"1\"/>\r\n </Style>\r\n " +
                     "<Style     ss:ID=\"StringLiteral\">\r\n <NumberFormat" +
                     " ss:Format=\"@\"/>\r\n </Style>\r\n <Style " +
                     "ss:ID=\"Decimal\">\r\n <NumberFormat " +
                     "ss:Format=\"0.0000\"/>\r\n </Style>\r\n " +
                     "<Style ss:ID=\"Integer\">\r\n <NumberFormat " +
                     "ss:Format=\"0\"/>\r\n </Style>\r\n <Style " +
                     "ss:ID=\"DateLiteral\">\r\n <NumberFormat " +
                     "ss:Format=\"mm/dd/yyyy;@\"/>\r\n </Style>\r\n " +
                     "</Styles>\r\n ";
            System.IO.StreamWriter excelDoc = null;
            excelDoc = new System.IO.StreamWriter(fileName);
            int sheetCount = 1;
            excelDoc.Write(startExcelXML);
            foreach (DataTable table in source.Tables)
            {
                int rowCount = 0;
                excelDoc.Write("<Worksheet ss:Name=\"" + table.TableName + "\">");
                excelDoc.Write("<Table>");
                excelDoc.Write("<Row>");
                for (int x = 0; x < table.Columns.Count; x++)
                {
                    excelDoc.Write("<Cell ss:StyleID=\"BoldColumn\"><Data ss:Type=\"String\">");
                    excelDoc.Write(table.Columns[x].ColumnName);
                    excelDoc.Write("</Data></Cell>");
                }
                excelDoc.Write("</Row>");
                foreach (DataRow x in table.Rows)
                {
                    rowCount++;
                    //if the number of rows is > 64000 create a new page to continue output
                    if (rowCount == 64000)
                    {
                        rowCount = 0;
                        sheetCount++;
                        excelDoc.Write("</Table>");
                        excelDoc.Write(" </Worksheet>");
                        excelDoc.Write("<Worksheet ss:Name=\"" + table.TableName + "\">");
                        excelDoc.Write("<Table>");
                    }
                    excelDoc.Write("<Row>"); //ID=" + rowCount + "
                    for (int y = 0; y < table.Columns.Count; y++)
                    {
                        System.Type rowType;
                        rowType = x[y].GetType();
                        switch (rowType.ToString())
                        {
                            case "System.String":
                                string XMLstring = x[y].ToString();
                                XMLstring = XMLstring.Trim();
                                XMLstring = XMLstring.Replace("&", "&");
                                XMLstring = XMLstring.Replace(">", ">");
                                XMLstring = XMLstring.Replace("<", "<");
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                               "<Data ss:Type=\"String\">");
                                excelDoc.Write(XMLstring);
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.DateTime":
                                //Excel has a specific Date Format of YYYY-MM-DD followed by  
                                //the letter 'T' then hh:mm:sss.lll Example 2005-01-31T24:01:21.000
                                //The Following Code puts the date stored in XMLDate 
                                //to the format above
                                DateTime XMLDate = (DateTime)x[y];
                                string XMLDatetoString = ""; //Excel Converted Date
                                XMLDatetoString = XMLDate.Year.ToString() +
                                     "-" +
                                     (XMLDate.Month < 10 ? "0" +
                                     XMLDate.Month.ToString() : XMLDate.Month.ToString()) +
                                     "-" +
                                     (XMLDate.Day < 10 ? "0" +
                                     XMLDate.Day.ToString() : XMLDate.Day.ToString()) +
                                     "T" +
                                     (XMLDate.Hour < 10 ? "0" +
                                     XMLDate.Hour.ToString() : XMLDate.Hour.ToString()) +
                                     ":" +
                                     (XMLDate.Minute < 10 ? "0" +
                                     XMLDate.Minute.ToString() : XMLDate.Minute.ToString()) +
                                     ":" +
                                     (XMLDate.Second < 10 ? "0" +
                                     XMLDate.Second.ToString() : XMLDate.Second.ToString()) +
                                     ".000";
                                excelDoc.Write("<Cell ss:StyleID=\"DateLiteral\">" +
                                             "<Data ss:Type=\"DateTime\">");
                                excelDoc.Write(XMLDatetoString);
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.Boolean":
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                            "<Data ss:Type=\"String\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.Int16":
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                excelDoc.Write("<Cell ss:StyleID=\"Integer\">" +
                                        "<Data ss:Type=\"Number\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.Decimal":
                            case "System.Double":
                                excelDoc.Write("<Cell ss:StyleID=\"Decimal\">" +
                                      "<Data ss:Type=\"Number\">");
                                excelDoc.Write(x[y].ToString());
                                excelDoc.Write("</Data></Cell>");
                                break;
                            case "System.DBNull":
                                excelDoc.Write("<Cell ss:StyleID=\"StringLiteral\">" +
                                      "<Data ss:Type=\"String\">");
                                excelDoc.Write("");
                                excelDoc.Write("</Data></Cell>");
                                break;
                            default:
                                throw (new Exception(rowType.ToString() + " not handled."));
                        }
                    }
                    excelDoc.Write("</Row>");
                }
                excelDoc.Write("</Table>");
                excelDoc.Write(" </Worksheet>");
                sheetCount++;
            }
            excelDoc.Write(endExcelXML);
            excelDoc.Close();
        }
