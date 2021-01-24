    //sample data
    Dictionary<string, Dictionary<int, int>> myDict1 = new Dictionary<string, Dictionary<int, int>>();            
    myDict1.Add("data1", new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } });
    myDict1.Add("data10", new Dictionary<int, int> { { 2, 10 }, { 3, 11 }, { 4, 0 } });
    Dictionary<string, Dictionary<int, int>> myDict2 = new Dictionary<string, Dictionary<int, int>>();
    myDict2.Add("data1", new Dictionary<int, int> { { 1, 1 }, {3, 1 }, { 4, 1 } });
    myDict2.Add("data2", new Dictionary<int, int> { { 2, 0 } });
    //here we will iterate only through common keys (that both dictionaries have it)
    foreach(string commonKey in myDict1.Keys.Intersect(myDict2.Keys))
        foreach(int intKey in myDict1[commonKey].Keys.Intersect(myDict2[commonKey].Keys))
            myDict2[commonKey][intKey] = myDict1[commonKey][intKey];
