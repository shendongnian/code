        //pseudocode...
        var totalLen = sortedDict.Length;
        for(var i = 0; i < ; i++)
        {
          var valToCheck = sortedDict[i];
          if(i-3 > totalLen && i+3 < totalLen)
          {
            if(
                sortedDict[i-3] < valToCheck && 
                sortedDict[i-2] < valToCheck && 
                sortedDict[i-1] < valToCheck
                &&
                sortedDict[i+1] < valToCheck &&
                sortedDict[i+2] < valToCheck &&
                sortedDict[i+3] < valToCheck
             ) 
             {
                Console.WriteLine(valToCheck);
             }
          }
        }
