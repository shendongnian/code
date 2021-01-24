    public TabPageModel
    {
        public Page1Model ModelPg1 {get;set;}
        public Page2Model ModelPg2 {get;set;}
        public Page3Model ModelPg3 {get;set;}
    }
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {
            InitializeComponent();
        }
        public MyTabbedPage(TabPageModel model) : this()
        {
            this.SubPage1.BindingContext = model.ModelPg1;
            this.SubPage2.BindingContext = model.ModelPg2;
            this.SubPage3.BindingContext = model.ModelPg3;
        }
    }
