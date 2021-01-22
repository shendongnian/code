    public string FormatEquation( IEnumerable<Equation> listEquations )
    {
        StringBuilder sb = new StringBuilder();
        const string separator = " and ";
        foreach( var eq in listEquations )
        {
            sb.Append( eq.ToString() );
            if( index == list.Equations.Count-1 )
                break;
            sb.Append( separator );
        }
    }
