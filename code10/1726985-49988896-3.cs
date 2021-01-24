    [assembly: Xamarin.Forms.Dependency(typeof(GetSmth))]
    public class Getsmth : IGetSmth
    {
        public string smth
        {
            get { return ReceiveDataFromApp.SomeTextInMainActivity; }
        }
    }
