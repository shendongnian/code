    void parseTextForOpenXML( Run run, string executiveSummary )
    {
        string[ ] newLineArray = { Environment.NewLine };
        string[ ] textArray = executiveSummary.Split( newLineArray, StringSplitOptions.None );
        
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
