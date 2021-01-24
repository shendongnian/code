    public newItemPage(Item item) // get selected listview tap model object using this constructor(Model.data item)
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
            Title = item.first_name;
            this.BindingContext = item; // binding using this 'item' model object and do whatever
        }
