    double higher = Double::MaxValue;
    double lower = Double::MinValue;
    
    double index = 5; // the value you want to get.
    List<double> list = {1,2,3,7,8,9}; // the list you're searching.
    
    for(int i = 0; i < list.Count; i++) 
    {
        if(list[i] > index && list[i] < higher)
            higher = list[i]; // sets the higher value.
        else if(list[i] < index && list[i] > lower)
            lower = list[i]; // sets the lower value.
    }
