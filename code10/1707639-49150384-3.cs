    public Dictionary<string,string> AsDictionary {
        get {
            Dictionary<string,string> temp = new Dictionary<>();
            for(int i = 0; i < Keys.Count; i++){
                temp.Add(Keys[i], Values[i]);
            }
            return temp;
        }
    }
