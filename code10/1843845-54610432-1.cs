    [DataContract]
    public class ClientState
    {
      private static object sync = new object( );
      
      //--> and then somewhat later...
      
      [DataMember( Name = "UpdateProblems", IsRequired = false, EmitDefaultValue = false )]
      List<UpdateProblem> updateProblems;
      /// <summary>Problems encountered during previous Windows Update sessions</summary>
      public List<UpdateProblem> UpdateProblems
      {
        get
        {
          lock ( sync )
          {
            if ( updateProblems == null ) updateProblems = new List<UpdateProblem>( );
          }
          return updateProblems;
        }
      }
      
      //--> ...and so on...
      
    }
