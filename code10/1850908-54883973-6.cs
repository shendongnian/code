          if (!row.IsNull(dt.FieldCaption))
              {
                  string value = row[dt.FieldCaption].ToString();
                  if(!string.IsNullOrEmpty(value))
                  {                               
                       bool toReturnBool;
                       bool toReturnInt;
                       if (int.TryParse(value, out toReturnInt))
                       {
                          // Datatype int
                          return toReturnInt;
                       }
                       else if (bool.TryParse(value, out toReturnBool))
                       {
                          // Datatype bool
                          return toReturnBool;
                       }
                       else
                       {
                         // assume that it's string.
                         return value;
                       }
                  }
              }
