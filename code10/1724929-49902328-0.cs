        double index = 5;
        double higher = 0 ;
        double lower = 0;
        int run_one_time = 0;
    
        List<double> list = new List<double>() { 1, 2, 3, 7, 8, 9, };
        
        if(!list.Contains(index))
        {
          foreach (var item in list)
          {
             if(item < index)
             {
                lower = item;                      
             }
             if (item > index && run_one_time == 0)
             {
                 run_one_time = 1;
                 higher = item;                       
             }
           }
         }
    Console.WriteLine(index);//5
    Console.WriteLine(lower);//3
    Console.WriteLine(higher);//7
