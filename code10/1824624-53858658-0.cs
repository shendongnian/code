    int sec = int.MinValue;
    for(int i =0, m= int.MinValue; i <list.Length; i++)
      if(list[i] > m){
        sec = m;
        m = list[i];
      }
