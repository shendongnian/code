    var printableClientAddress =
        string.Join( "", client.ClientAddress
                               .Select( c => char.IsControl(c)
                                                ? Environment.NewLine
                                                : c )
                               .ToArray() );
