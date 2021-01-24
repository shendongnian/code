    var query = input.GroupBy(
        item => item.CategoryId,              // Key projection
        item => item.Value,                   // Element projection
        // Result projection. (You may want to add ToList within the lambda to materialize.)
        (key, values) => new { Key = key, Values = string.Join(", ", values.Distinct()) });
