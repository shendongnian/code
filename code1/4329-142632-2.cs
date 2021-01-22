    sealed class DomainObjectFilter {
      private readonly Func<DomainObject,string> memberSelector_;
      public DomainObjectFilter( Func<DomainObject,string> memberSelector ) {
        this.memberSelector_ = memberSelector;
      }
      
      public bool ShouldInclude( DomainObject o, string target ) {
        string member = this.memberSelector_( o );
        return string.IsNullOrEmpty( target )
            || member.Contains( target );
      }
    }
    
    ...
    ddlFileName.Tag = new DomainObjectFilter( o => o.FileName );
