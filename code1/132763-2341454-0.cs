        sw.Reset();
        sw.Start();
        for (int i = 0; i < nr; i++)
        {          
            DoesContain(list,"zzz");            
        }
        total += sw.ElapsedMilliseconds;
        Console.WriteLine(total / nr);
