    var dictionaryOfDictionaries = 
        myDic.GroupBy(pair => pair.Key.KeyType)
             .ToDictionary(gr => gr.Key,         // key of the outer dictionary
                 gr => gr.ToDictionary(item => item.Key,  // key of inner dictionary
                                       item => item.Value)); // value
