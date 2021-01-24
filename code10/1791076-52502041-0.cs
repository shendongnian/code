    public void button1_Click(object sender, EventArgs e)
    {
        using(XLWorkbook libro_trabajo = new XLWorkbook())
        {
            DataSet ps = datos_referencias();
            libro_trabajo.Worksheets.Add(ps);
            libro_trabajo.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            libro_trabajo.Style.Font.Bold = true;
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=reporte_clientes.xlsx");
            
            using (MemoryStream memoria = new MemoryStream())
            {
                
                libro_trabajo.SaveAs(memoria);
                memoria.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
                
            }
        }
    }
