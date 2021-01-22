    public QueryStringParser(string QueryString)
            {
                //check if string is empty
                if (string.IsNullOrEmpty(QueryString))
                    this._mode = Mode.First;
                else
                {
                   bool hasFirst = QueryString.Contains(_FristFieldName);
                   bool hasSecond= QueryString.Contains(_SecondFieldName);
                   //check if string contains first field name but not second field name
                   if (hasFirst  && !hasSecond)
                       this._mode = Mode.Second;
                   //check if string contains second field name but not first field name
                   else if (!hasFirst && hasSecond)
                       this._mode = Mode.Third;
                   //default - error
                   else
                       throw new ArgumentException("QueryString has wrong format");
                }
            }
