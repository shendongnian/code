    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<SomeOtherClass, InspectionSchemeChecks>(this, "InspectionSchemeChecks", OnNewMessage);
        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<SomeOtherClass, InspectionSchemeChecks>(this, "InspectionSchemeChecks");
            base.OnDisappearing();
        }
        private void OnNewMessage(SomeOtherClass sender, InspectionSchemeChecks schemeChecks)
        {
            // Do what you want
        }
    }
    public class SomeOtherClass
    {
        public void SaveButton_Clicked(object sender, EventArgs e)
        {
            var SchemeChecks = new InspectionSchemeChecks();
            var InspectionList = new List<InsScheme>();
            //...
            SchemeChecks.InsScheme = InspectionList;
            MessagingCenter.Send<SomeOtherClass, InspectionSchemeChecks>(this, "InspectionSchemeChecks", SchemeChecks);
        }
    }
