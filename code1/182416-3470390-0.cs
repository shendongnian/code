    public class Car : Vehicle 
    { 
        private String _model; 
        public String Model 
        { 
            get { return _model; } 
            set { SomeMethod("Model", ref _model, value); } 
        } 
    } 
