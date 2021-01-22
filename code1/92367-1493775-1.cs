    AppendProperties(_gridModel, "Header", "Width", "Align", ...)
    
    void AppendProperties(object src, object item, params string [] propNames)
    {
     foreach (string propName in propNames)
     {
      // get src property and append "," if not null
      // get item property and append it if value is not null
     }
    }
