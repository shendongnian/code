         string inputFile = filename;
         string outputFile = Path.Combine( workingdirform2, "configuration.txt" );
         using ( StreamReader inputFileStream = File.OpenText( inputFile ) ) 
         {           
            using ( StreamWriter ouputFileStream =  File.AppendText( outputFile )  )
            {
               // Iterate over the file contents to extract the prefix
               string currentLine;
               while ( ( currentLine = inputFileStream.ReadLine() ) != null )
               {
                  // Notice the updated Regex - your's is a bit broken
                  string prefix = Regex.Match( currentLine, @"^(\S+?)\d+" ).Groups[1].Value;
                  ouputFileStream.WriteLine( prefix );
               }
            }
         }
