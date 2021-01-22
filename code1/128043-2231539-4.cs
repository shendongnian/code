    public string FormatEquation( IEnumerable<Equation> listEquations )
    {
        StringBuilder sb = new StringBuilder();
        if( listEquations.Count > 0 )
            sb.Append( listEquations[0].ToString() );
        for( int i = 1; i < listEquations.Count; i++ )
            sb.Append( " and " + listEquations[i].ToString() );
        return sb.ToString();
    }
