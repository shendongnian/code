    Size = a.Type == "Machines"  
      ? a.Info.DiskInfo // object
         .Select(b => b.Size) // IEnumerable<string>
         .Select(c => Regex.Replace(c, "[^0-9.]", ""))) // IEnumerable<string>
         .Where(x => !string.IsNullOrWhiteSpace(x)) // IEnumerable<string>
         .Select(x => Convert.ToDecimal(x.Trim())) // IEnumerable<decimal>
         .Sum() // single decimal
         .ToString() // single string
      : null,
