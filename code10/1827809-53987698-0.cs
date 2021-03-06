    // Get pupils and calculate max height
    var pupils = 
        Enumerable.Range(0, int.MaxValue)
                   .Select(i => Console.ReadLine())
                   .TakeWhile(input => string.IsNullOrWhiteSpace(input) == false)
                   .Select(input => input.Split(':'))
                   .Select(values =>
                   {
                       var name = values.First();
                       var validHeight = int.TryParse(values.Last(), out int height);
                       return (Name: name, Height: height, Valid: validHeight);
                   })
                   .Where(pupil => pupil.Valid)
                   .ToList();
    var maxHeight = pupils.Max(pupil => pupil.Height);
    // Build output string
    var outputBuilder = new StringBuilder();
    outputBuilder.AppendLine(maxHeight.ToString());
    var output = 
        pupils.Where(pupil => pupil.Height == maxHeight)
              .Aggregate(outputBuilder, (builder, pupil) => builder.AppendLine(pupil.Name))
              .ToString();
    Console.WriteLine(output);
