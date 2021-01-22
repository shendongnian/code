    DateTime? firstIssueDate = r.Field<DateTime?>("fiss"); 
    DateTime? endIssueDate = r.Field<DateTime?>("eiss"); 
    
    if (firstIssueDate.HasValue && endIssueDate.HasValue) 
    { 
        firstIssueDate.Value // blah blah 
        endIssueDate.Value // blah blah 
    }
