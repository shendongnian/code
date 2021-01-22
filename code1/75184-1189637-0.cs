         string myString = "cat,dog,\"0 = OFF, 1 = ON\",lion,tiger,'R = red, G = green, B = blue',bear";
         bool inQuotes = false;
         char delim = ',';
         List<string> strings = new List<string>();
         StringBuilder sb = new StringBuilder();
         foreach( char c in myString )
         {
            if(c == '\'' || c == '"')
            {
               if(!inQuotes)
                  inQuotes = true;
               else
                  inQuotes = false;
            }
            if( c == delim )
            {
               if( !inQuotes )
               {
                  strings.Add( sb.Replace("'", string.Empty).Replace("\"", string.Empty ).ToString());
                  sb.Remove( 0, sb.Length );
               }
               else
               {
                  sb.Append( c );
               }
            }
            else
            {
               sb.Append( c );
            }
         }
         foreach( string s in strings )
            Console.WriteLine( s );
Output:
cat
dog
0 = OFF, 1 = ON
lion
tiger
R = red, G = green, B = blue
