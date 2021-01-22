    var numbers = values.Select(
        s => {
            int n;
            if (!int.TryParse((s ?? string.Empty), out n)) 
            {
                return (int?)null;
            }
            return (int?)n;
        }
    )
    .Where(n => n != null)
    .Select(n => n.Value)
    .ToArray();
