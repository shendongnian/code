    ...
    foreach (var location in reference.Locations)
    {
        if (location.Document.TryGetSemanticModel(out var referenceSemanticModel))
        {
            var enclosingSymbol = referenceSemanticModel.GetEnclosingSymbol(location.Location.SourceSpan.Start);
            if (!(enclosingSymbol is null))
            {
                // NOTE: if your symbol are referenced by lambda then this name 
                // would be the innermost enclosing member which contains lambda,
                // so be careful
                var name = enclosingSymbol.Name;
            }
        }
    }
