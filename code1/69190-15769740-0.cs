    DateTime startTime = DateTime.Now;
    DateTime endTime = DateTime.Now.AddSeconds( 75 );
    TimeSpan span = endTime.Subtract ( startTime );
     Console.WriteLine( "Time Difference (seconds): " + span.Seconds );
     Console.WriteLine( "Time Difference (minutes): " + span.Minutes );
     Console.WriteLine( "Time Difference (hours): " + span.Hours );
     Console.WriteLine( "Time Difference (days): " + span.Days );
