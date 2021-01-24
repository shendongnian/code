    private string _provinceCode;
    
    public string ProvinceCode
    {
      get 
      {
         if(string.IsNullOrEmpty(_provinceCode)) {
            _provinceCode = "CODE";
         }
         return _provinceCode;
      }
      set 
      {
         _provinceCode = value;
      }     
    }
