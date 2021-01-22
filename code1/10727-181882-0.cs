    const string notInsideBracketsRegex = @"(?<!<[^>]*)";
    const string highlightPattern = @"<span class=""Highlight"">$0</span>";
    DataBoundLiteralControl litCustomerComments = (DataBoundLiteralControl)e.Row.Cells[CUSTOMERCOMMENTS_COLUMN].Controls[0];
    
    // Turn "term1 term2" into "(term1|term2)"
    string spaceDelimited = txtTextFilter.Text.Trim();
    string pipeDelimited = string.Join("|", spaceDelimited.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries));
    string searchPattern = "(" + pipeDelimited + ")";
    searchPattern = notInsideBracketsRegex + searchPattern;
    
    // Highlight search terms in Customer - Comments column
    e.Row.Cells[CUSTOMERCOMMENTS_COLUMN].Text = Regex.Replace(litCustomerComments.Text, searchPattern, highlightPattern, RegexOptions.IgnoreCase);
