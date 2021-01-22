    private Item _myResult;
    public Item Result
    {
         get
         {
              if (_myResult == null)
              {
                   _myResult = Database.DoQueryForResult();
              }
              return _myResult;
         }
    }
