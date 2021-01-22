    public class CustomerViewModel : ViewModel
    {
        private bool isSelected;
    
        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                 if (this.isSelected != value)
                 {
                     this.isSelected = value;
                     this.OnPropertyChanged(() => this.IsSelected);
                 }
            }
        }
    }
