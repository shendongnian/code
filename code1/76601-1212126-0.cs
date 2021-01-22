    var tr = new TableRow { CssClass = "" };
                
    tr.Cells.AddRange(new []
    {
        new TableCell { CssClass = "", Text = "Hello" },
        new TableCell { CssClass = "", Text = new Func<String>(() => 
        {
            // logic goes here
            return "";
        })()}
    });
