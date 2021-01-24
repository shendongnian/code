    int tbl=53;
    
        while  (tbl < 96)
        {
           if (tbl % 7 == 0){
              Console.WriteLine(tbl);
              tbl+=7;
              continue;
           }
           tbl++;
        }
