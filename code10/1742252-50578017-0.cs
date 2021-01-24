    string result= "";
    list1.ForEach(item => {
    yourDictionary.ToList().ForEach
    (
        pair =>
        {
            if (pair.Value.Contains(item.ToString()))
            {
                result = result + pair.Value + ", ";
            }
        }
    );
    });
    
