    public partial class MyClass {
        private string _text;
        public virtual string Text {
            get { return this._Text; }
            set {
                this.OnPropertyChanging( "Text" );
                this._Text = value;
                this.OnPropertyChanged( "Text" );
            }
        }
    }
