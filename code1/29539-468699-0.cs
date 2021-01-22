    int? optionalTimeout = UseTimeout ? Timeout : null;
    switch (ReadDecision) {
        case ReadDecisions.ReadNext:
            Message = queue.Receive( optionalTimeout ); break;
    
        case ReadDecisions.PeekNext:
            Message = queue.Peek( optionalTimeout ); break;
    
        // and so on ...
