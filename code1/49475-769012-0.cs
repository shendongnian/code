    DateTime now = DateTime.Today;
    for (int i = 0; i < 7; ++i )
    {
        for (int j = 0; j < 7; ++j )
        {
             now = now.AddDays( 1 / 7.0 );
        }
    }
    Console.WriteLine( DateTime.Today);
    Console.WriteLine( now );
