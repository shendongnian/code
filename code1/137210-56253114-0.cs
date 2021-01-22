    var m = new
    {
        Items = new[]
        {
            new { Total = 10, Done = 1 },
            new { Total = 10, Done = 1 },
            new { Total = 10, Done = 1 },
            new { Total = 10, Done = 1 },
            new { Total = 10, Done = 1 },
        },
    };
    
    var itemSums = m.Items.Aggregate((Total: 0, Done: 0), (sums, item) => (sums.Total + item.Total, sums.Done + item.Done));
    
    Console.WriteLine($"Sum of Total: {itemSums.Total}, Sum of Done: {itemSums.Done}");
