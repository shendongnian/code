    Console.WriteLine(BytesToString(9223372036854775807));  //Results in 8EB
    Console.WriteLine(BytesToString(0));                    //Results in 0B
    Console.WriteLine(BytesToString(1024));                 //Results in 1KB
    Console.WriteLine(BytesToString(2000000));              //Results in 1.9MB
    Console.WriteLine(BytesToString(-9023372036854775807)); //Results in -7.8EB
