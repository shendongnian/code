    namespace MyApp
    {
        public partial class MainPage : ContentPage
        {
            public bool foo = true; //just an example
    
            public MainPage()
            {
                InitializeComponent();
            }
        }
    	//I suppose invoking any event lets says button click calling interface dependency service of android project
    	void Button_Clicked(object sender,EventArgs e)
    	{
    		object resultado = DependencyService.Get<IPortableInterface>().Test();
    	}
               
    }
