    using (StringWriter sw = new StringWriter())
    {
      Table t = new Table();
      TableRow tr = new TableRow();
      TableCell td = new TableCell {Text = "Some text... Istanbul"};
      
      tr.Cells.Add(td);
      t.Rows.Add(tr);
    
      t.RenderControl(new HtmlTextWriter(sw));
    
      string html = sw.ToString();
    }
