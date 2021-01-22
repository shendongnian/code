     class DKD {
            List<Dictionary<string, string>> dictionaries;
            public DKD(){
                dictionaries = new List<Dictionary<string, string>>();}
            public object this[string key]{
                 get{
                    string temp;
                    List<string> valueList = new List<string>();
                    for (int i = 0; i < dictionaries.Count; i++){
                        dictionaries[i].TryGetValue(key, out temp);
                        if (temp == key){
                            valueList.Add(temp);}}
                    return valueList;}
                set{
                    for (int i = 0; i < dictionaries.Count; i++){
                        if (dictionaries[i].ContainsKey(key)){
                            continue;}
                        else{
                            dictionaries[i].Add(key,(string) value);
                            return;}}
                    dictionaries.Add(new Dictionary<string, string>());
                    dictionaries.Last()[key] =(string)value;
                }
            }
        }
