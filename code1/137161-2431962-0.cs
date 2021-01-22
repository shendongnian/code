    public double GetAge()
    {
       try
       {
          var input = _dataProvider.GetInput();
          return Convert.ToDouble(input);
       }
       catch(Exception ex)
       {
          throw new MyBackendException(ex);
       }
    }
