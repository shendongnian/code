    public QueryStringParser(string QueryString)
            {
                //check if string is empty
                if (string.IsNullOrEmpty(QueryString))
                    this._mode = Mode.First;
                //check if string contains first field name but not second field name
                else if (QueryString.Contains(_FristFieldName) && !QueryString.Contains(_SecondFieldName))
                    this._mode = Mode.Second;
                //check if string contains second field name but not first field name
                else if (!QueryString.Contains(_FristFieldName) && QueryString.Contains(_SecondFieldName))
                    this._mode = Mode.Third;
                //default - error
                else
                    throw new ArgumentException("QueryString has wrong format");
            }
