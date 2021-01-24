    public string ProvinceCode
      {
        get 
         {
            return provinceCode;
         }
       set 
        {
           provinceCode = value;
        }     
     }
    public Form1()
    {
        //HTGetProvinces() returns a list of provinces
        InitializeComponent();
        List<HTProvince> provinceList =
            HTProvince.HTGetProvinces();
        foreach (HTProvince x in provinceList)
        {
            //Works. Adds items the province code property of for each item to my list
            provincesListBox.Items.Add(x.ProvinceCode); 
        }
    }
