    public class ContactViewModel : ViewModelBase {
        private string id;
        /// <summary>
        /// Id of the contact.
        /// </summary>
        public int Id {
            get { return id; }
            set {
                id = value;
                OnPropertyChanged();
            }
        }
        
        string lastname;
        /// <summary>
        /// Lastname of the contact.
        /// </summary>
        public string Lastname {
            get { return lastname; }
            set {
                lastname = value;
                OnPropertyChanged();
            }
        }
        
        string firstname
        /// <summary>
        /// Firstname of the contact.
        /// </summary>
        public string Firstname {
            get { return firstname; }
            set {
                firstname = value;
                OnPropertyChanged();
            }
        }
        
        string email;
        /// <summary>
        /// Email of the contact.
        /// </summary>
        public string Email {
            get { return email; }
            set {
                email = value;
                OnPropertyChanged();
            }
        }
        string address;
        /// <summary>
        /// Address of the contact.
        /// </summary>
        public string Address {
            get { return address; }
            set {
                address = value;
                OnPropertyChanged();
            }
        }
        string notes;
        /// <summary>
        /// Notes of the contact.
        /// </summary>
        public List<Note> Notes {
            get { return notes; }
            set {
                notes = value;
                OnPropertyChanged();
            }
        }
    }
