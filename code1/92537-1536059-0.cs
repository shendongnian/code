    private void TimerTick(object sender, EventArgs e)
    {
       try
       {
           var solution = applicationObject.Solution;
           if (solution.IsOpen && string.IsNullOrEmpty(solution.FileName) == false)
           {
               timer.Stop();
               // insert logic here
           }
       }
       catch (Exception exception)
       {
           Console.WriteLine(exception);
       }
    }
