    public CombWithEnum () // This is the contructor
    {
        this.InitializeComponent();
        this.EnumsCombo(); 
    }
    
    public void EnumsCombo () // This is the method that will load the ComboBox
    {
         var _enumval = Enum.GetValues​​(typeof (Proyect.Model.TYPE_IDENTITY)).Cast<Proyect.Model.TYPE_IDENTITY> ();
         var x = _enumval.ToList();
         CobIdenti.ItemsSource = x;
    }
