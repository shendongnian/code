      private IJwtHelper _jwtHelper;
      public SomeConstructerOnClass(IJwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }
     public void SomeMethod(string property) {
        var token = _jwtHelper.GetValueFromToken(property);
        //Do something with token
        }
