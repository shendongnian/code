    _gridModel.Header = AppendItem(_gridModel.Header, item.Header);
    _gridModel.Width = AppendItem(_gridModel.Width, item.Width);
    ...
    ...
    
    string AppendItem(string src, string item)
    {
     if (! string.IsNullOrEmpty(src))
      src += ",";
     if (! string.IsNullOrEmpty(item))
      src += item;
     return src;
    }
