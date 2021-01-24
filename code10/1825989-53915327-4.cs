    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ContactViewModel()
        {
        }
        /// <summary>
        /// Event when property changed.
        /// </summary>
        /// <param name="s">string</param>
        void OnPropertyChanged(string s)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
        
        /// <summary>
        /// Id of the contact.
        /// </summary>
        public int Id {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        
        /// <summary>
        /// Lastname of the contact.
        /// </summary>
        public string Lastname {
            get
            {
                return Lastname;
            }
            set
            {
                Lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }
        /// <summary>
        /// Firstname of the contact.
        /// </summary>
        public string Firstname {
            get
            {
                return Firstname;
            }
            set
            {
                Firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        /// <summary>
        /// Email of the contact.
        /// </summary>
        public string Email {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        /// <summary>
        /// Address of the contact.
        /// </summary>
        public string Address
        {
            get
            {
                return Address;
            }
            set
            {
                Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        /// <summary>
        /// Notes of the contact.
        /// </summary>
        public List<Note> Notes
        {
            get
            {
                return Notes;
            }
            set
            {
                Notes = value;
                OnPropertyChanged(nameof(Notes));
            }
        }
    }
