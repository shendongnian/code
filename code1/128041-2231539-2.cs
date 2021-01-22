    public string FormatEquation( IEnumerable<Equation> listEquations )
    {
        StringBuilder sb = new StringBuilder();
        const string separator = " and ";
        foreach( var eq in listEquations )
            sb.Append( eq.ToString() + separator );
        if( listEquations.Count > 1 )
            sb.Remove( sb.Length, separator.Length );
    }
