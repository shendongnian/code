    public SaveEvaluation( Evaluation eval )
    {
       // .. common save logic ..
       dynamic evalDyn = eval;
  
       SaveChild( evalDyn );
    }
    private void SaveChild( ChildA eval ) { ... }
    private void SaveChild( ChildB eval ) { ... }
