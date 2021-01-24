    string text = rawData;
            
    //Raw Data Is the exact data you read from textfile without modifications.
    List<MyData> myDataList  = new List<MyData>();
    string[] eElco = text.Split( new[] { Environment.NewLine }, StringSplitOptions.None );
    var tmem = eElco.Count();
    var eachP = tmem / 3;
            
    List<string> unDefVal = new List<string>();
    foreach (string rw in eElco)
    {
        String onlyVal = rw.Split(new[] { "Value: " } , StringSplitOptions.None)[1];
        unDefVal.Add(onlyVal);
    }
            
    for (int i = 0; i < eachP; i++)
    {
        int ind = Int32.Parse(unDefVal[i + eachP]);
        DateTime oDate = DateTime.ParseExact(unDefVal[i], "dd/MM/yyyy hh:mm:ss",System.Globalization.CultureInfo.InvariantCulture);
                
        MyData data1 = new MyData();
        data1.DateTime = oDate;
        data1.Index = ind;
        data1.Value = unDefVal[i + eachP + eachP];
        myDataList.Add(data1);
                
        Console.WriteLine("Val1 = {0}, Val2 = {1}, Val3 = {2}",
        myDataList[i].Index,
        myDataList[i].DateTime,
        myDataList[i].Value);    
    }
