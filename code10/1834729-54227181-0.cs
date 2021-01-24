            FileInfo fi = new FileInfo("FILE LOCATION");
            StreamReader reader = new StreamReader( fi.ToString() );
            String Line = "";
            while ( ( Line = reader.ReadLine() ) != null )
            {
                if ( !Line.Contains("Dimension text") {
                    continue;
                }
                String Property = Line.Split( '=' )[0];
                String Value = Line.Substring( Property.Length + 1, Line.Length - Property.Length - 1 );
                Console.WriteLine( Value ); // This line will print value of Dimension text
            }
