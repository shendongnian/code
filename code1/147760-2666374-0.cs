    public QueryStringParser(string QueryString)
            {
                // Input is NULL STRING
                if (string.IsNullOrEmpty(QueryString))
                {
                    this._mode = Mode.First;
                }
                // Query using FirstName
                else if (QueryString.Contains(_FristFieldName) &&
                        !QueryString.Contains(_SecondFieldName))
                {
                    this._mode = Mode.Second;
                }
                //Query using SecondName
                else if (!QueryString.Contains(_FristFieldName) &&
                          QueryString.Contains(_SecondFieldName))
                {
                    this._mode = Mode.Third;
                }
                //Insufficient info to Query data
                else
                {
                    throw new ArgumentException("QueryString has wrong format");
                }
            }
