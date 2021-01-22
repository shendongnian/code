    public class Contact : Bindable {
        public string FirstName {
            get { return Get<string>(); }
            set { Set(value); }
        }
    }
