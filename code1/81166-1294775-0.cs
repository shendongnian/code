    HtmlTable localTable1 = new HtmlTable();
    HtmlTableCell cell1 = new HtmlTableCell();
    HtmlTableCell cell2 = new HtmlTableCell();
    
    foreach (Evaluation eval in theEvaluations)
    {
        HtmlTableRow anEvaluation = new HtmlTableRow();`
    
        cell1.InnerText = eval.attr1;
        anEvaluation.Cells.Add(cell1);
    
        cell1.InnerText = eval.attr1;
        anEvaluation.Cells.Add(cell2);
    
        localTable1.Rows.Add(anEvaluation);
    }
    
    // And eventually here I should pass the localTable1 to table1
