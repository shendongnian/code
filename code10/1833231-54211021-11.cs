    public class CustomEntry: Entry
    {
        public delegate void BackButtonPressEventHandler(object sender, EventArgs e);
    
        public event BackButtonPressEventHandler OnBackButton;
    
        public CustomEntry() { }
    
        public void OnBackButtonPress() 
        {
            if (OnBackButton!= null)
            {
                OnBackButton(null, null);
            }
        }
    }
