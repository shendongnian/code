    StopWatch timer = new StopWatch();
    timer.Start();
    for(int i=0;i<100;++i)
    {
         using(SqlConnection conn = new SqlConnection("SomeConnectionString"))
         {
             test.Open();
         }
    }
    timer.Stop();
    Console.WriteLine(test.Elapsed.Milliseconds/100);
