    var head = new List<char>("abcdef");
    var heel = new List<char>("123456");
    heel = heel.Concat(heel);
    
    var randomer = new Random();
    
    foreach (var knownItem in head)
    {
        var idx1 = randomer.Next(heel.Count);
        var pair1 = heel[idx1];
        heel.RemoveAt(idx1);
        char pair2='\0';            
        while (true)
        {
           var idx2 = randomer.Next(heel.Count);
           pair2 = heel[idx2];
           if (pair2 != pair1)
           {
              heel.RemoveAt(idx2);
              break;
           }
        }
    
        //DoTheDew
    }
