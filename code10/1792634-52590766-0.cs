    private void BuildAYSONationalFeed(HttpContext context, DataTable feedDataTable)
        {
            DataSet dataSet = new DataSet("Portals");
            dataSet.Tables.Add(feedDataTable);
            context.Response.Clear();
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.ContentType = "text/xml";
            context.Response.Write(dataSet.GetXml());
            context.Response.Flush();
            context.Response.End();
        }
