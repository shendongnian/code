    var tr = new TableRow();
    
    tr.Cells.AddRange
    (
        new[]
        {
            new TableCell { Text = "" },
            new TableCell { Text = "" },
            new TableCell { Text = "" },
    
            new TableCell { Text = new Func<String>(() =>
                {
                    return @"Result of a chunk of logic, without having to define
                             the logic outside of the TableCell constructor";
                })()
            },
    
            new TableCell { Text = "" },
            new TableCell { Text = "" }
        }
    );
