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
                             this table-cell's text outside of the constructor or
                             in a seperate method";
                })()
            },
    
            new TableCell { Text = "" },
            new TableCell { Text = "" }
        }
    );
