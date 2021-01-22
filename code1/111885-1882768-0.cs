    private bool _IsDeleted;
    public bool IsDeleted
    {
       get
       {
          return _IsDeleted || (Parent == null ) ? false : Parent.IsDeleted;
       }
       set
       {
          _IsDeleted = value;
       }
    }
       
