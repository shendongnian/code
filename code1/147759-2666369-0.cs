    public QueryStringParser(string QueryString) {
        if (string.IsNullOrEmpty(QueryString))
            this._mode = Mode.First;
        else {
            bool has_1st = QueryString.Contains(_FristFieldName);
            bool has_2nd = QueryString.Contains(_SecondFieldName);
            if      ( has_1st && !has_2nd) this._mode = Mode.Second;
            else if (!has_1st &&  has_2nd) this._mode = Mode.Third;
            else
                throw new ArgumentException("QueryString has wrong format");
        }
    }
