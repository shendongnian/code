    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      string decodedText =HttpUtility.HtmlDecode(e.Row.Cells[0].Text);
      e.Row.Cells[0].Text = decodedText;
    }
