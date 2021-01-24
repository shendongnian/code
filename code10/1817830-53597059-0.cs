    var inputs =
    @"{ 0,0,0,1,0,0,0 },
    { 0,0,0,1,1,0,0 },";
    var lines = inputs.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
    var dim =
        lines.Select(
            line =>
            line.Trim(new[] {'{', '}', ','})
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(element => int.Parse(element))
                .ToArray()
        ).ToList();
