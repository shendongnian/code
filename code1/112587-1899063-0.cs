    class BasePresenter
    {
        public bool CanGotoHome 
        { 
            get { return IsLoggedIn; } 
        }
    }
    class HomePresenter : BasePresenter
    {
        public bool CanGotoHome 
        { 
            get { return False; } 
        }
    }
