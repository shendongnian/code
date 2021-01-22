    // Given:
    internal interface I { void M(); }
    
    // Then explicit implementation correctly observes encapsulation of I:
    // Both ((I)CExplicit).M and CExplicit.M are accessible only internally.
    public class CExplicit: I { void I.M() { } }
    
    // However, implicit implementation breaks encapsulation of I, because
    // ((I)CImplicit).M is only accessible internally, while CImplicit.M is accessible publicly.
    public class CImplicit: I { public void M() { } }
