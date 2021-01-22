    void parseTextForOpenXML( Run run, string textualData )
    {
        string[ ] newLineArray = { Environment.NewLine };
        string[ ] textArray = textualData.Split( newLineArray, StringSplitOptions.None );
        
        bool first = true;
        
        foreach ( string line in textArray )
        {
            if ( ! first )
            {
                run.Append( new Break( ) );
            }
            
            first = false;
            
            Text txt = new Text( );
            txt.Text = line;
            run.Append( txt );
        }
