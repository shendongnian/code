    public class SelectedEmployeesViewModel : ViewModelBase
    {
        /* ...other stuff... */
        private Gender _gender = Gender.Male;
        public Gender gender
        {
            get { return _gender; }
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }
    }
    public enum Gender
    {
        Male, Female
    }
    public static class EnumValues
    {
        public static IEnumerable<Gender> Genders => Enum.GetValues(typeof(Gender)).Cast<Gender>();
    }
