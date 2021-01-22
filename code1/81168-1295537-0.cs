    foreach (Evaluation eval in theEvaluations)
    {
        HtmlTableRow anEvaluation = new HtmlTableRow();
        HtmlTableCell cell1 = new HtmlTableCell();
        HtmlTableCell cell2 = new HtmlTableCell();
        
    
        cell1.InnerText = eval.attr1;
        anEvaluation.Cells.Add(cell1);
    
        cell2.InnerText = eval.attr2;
        anEvaluation.Cells.Add(cell2);
    
        table1.Rows.Add(anEvaluation);  // table1 : the real HTML table in ASP page
    }
