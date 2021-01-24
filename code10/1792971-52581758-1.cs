    class DefaultPasswordReqs
    {
      public int MaxLength { get; set; }
      // ...
    }
    class DefaultPasswordGenerator : IPasswordGenerator<DefaultPasswordReqs>
    {
      public string GeneratePassword(DefaultPasswordReqs reqs)
      {
        // ... logic specific to DefaultPasswordReqs
      }
    }
    class InMemoryPasswordRequiremntsRepository<TPasswordRequirements> : 
      IPasswordRequirementRepository<TPasswordRequirements>
    {
      private readonly TPasswordRequirements _reqs;
      public InMemoryPasswordRequiremntsRepository(TPasswordRequirements reqs)
      {
        _reqs = reqs;
      }
      public TPasswordRequirements GetPasswordRequirements()
      {
        return _reqs;
      }
    }
