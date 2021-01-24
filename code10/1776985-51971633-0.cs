    for (int i=15; i< 25; i++)
        {
            for( int j=1; j< 20; j++)
            {
                if(j < 4)
                {
                    Console.WriteLine(dt2.Rows[i][j]);
                }
                else
                {
                   if (dt2.Rows[i][j] does not equal 0 or null) 
                   {
                       Console.WriteLine(dt2.Rows[i-some_fixed_#_of_rows][j]);
                   }
                   else
                   {
                       ...
                   }
                }
            }
        }
