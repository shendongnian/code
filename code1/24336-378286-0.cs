    private string stripCellText(string text)
    {
          return text.Replace("\r\a", "");
    }
    
    string text = stripCellText(wordTable.cell(tablerow.index, 1).Range.Text);
