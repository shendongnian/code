    namespace RadioButtonMvvmDemo
    {
        public enum ListButtons {ButtonA, ButtonB}
    
        public class Window1ViewModel : ViewModelBase
        {
            private ListButtons p_SelectedButton;
    
            public Window1ViewModel()
            {
                SelectedButton = ListButtons.ButtonB;
            }
    
            /// <summary>
            /// The button selected by the user.
            /// </summary>
            public ListButtons SelectedButton
            {
                get { return p_SelectedButton; }
    
                set
                {
                    p_SelectedButton = value;
                    base.RaisePropertyChangedEvent("SelectedButton");
                }
            }
    
        }
    } 
