    String[] findValues = this.textBox16.Text.Split( new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries );
    List<Int32> matchingLineNumbers = new List<Int32>();    
    using( StreamReader rdr = new StreamReader( "watcher.text" ) )
    {
        String line;
        Int32 lineNumber = 1;
        while( ( line = rdr.ReadLine() ) != null )
        {
            foreach( String value in findValues )
            {
                if( line.IndexOf( value, StringComparison.OrdinalIgnoreCase ) > -1 )
                {
                    matchingLineNumbers.Add( lineNumber );
                }
            }
            lineNumber++;
        }
    }
    if( matchingLineNumbers.Count == 0 )
    {
        MessageBox.Show( "Item not on list" );
    }
    else
    {
        String message = "Matching lines: " + String.Join( ", ", matchingLineNumbers.Select( n => n.ToString() ) );
        MessageBox.Show( message  );
    }
