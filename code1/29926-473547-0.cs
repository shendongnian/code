       s1 = MakeNiceString( "LookOut,Momma,There'sAWhiteBoatComingUpTheRiver" ) );
       private string MakeNiceString( string input )
       {
           StringBuilder sb = new StringBuilder( input );
           int Incrementer = 0;
           MatchCollection mc;
           const string SPACE = " ";
    
           mc = Regex.Matches( input, "[A-Z|,]" );
    
           foreach ( Match m in mc )
           {
               if ( m.Index > 0 )
               {
                   sb.Insert( m.Index + Incrementer, SPACE );
                   Incrementer++;
               }
           }
           
           return sb.ToString().TrimEnd();
       }
