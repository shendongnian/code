         using ( StreamReader reader = new StreamReader( File.OpenRead( filename ) ) ) {
            using ( StreamWriter writer = new StreamWriter( File.OpenWrite( workingdirform2 + "configuration.txt" ) ) ) {
               string currentLine;
               while ( ( currentLine = reader.ReadLine() ) != null ) {
                  // Notice the updated Regex - your's is a bit broken
                  string firstToken = currentLine.Split( '|' )[0];  // Not really necessary
                  string prefix = Regex.Match( firstToken, @"^(\S+?)(\d+)" ).Groups[1].Value;
                  writer.WriteLine( prefix );
               }
            }
         }
