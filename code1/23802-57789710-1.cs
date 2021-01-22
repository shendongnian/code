    [AllowNull]
    public string Path
    {
          get
          {
              return _path;
          }
          set
          {
              if ((value == null) || (value.Length == 0))
              {
                  value = "/";
              }
              _path = Uri.InternalEscapeString(value.Replace('\\', '/'));
              _changed = true;
          }
     }
