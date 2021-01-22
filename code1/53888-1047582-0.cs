     public class FixError : System.Windows.Ria.Data.Entity
    {
        private string _Name;
        [Required]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.ValidateProperty("Name", value);
                    this.RaiseDataMemberChanging("Name");
                    this._Name = value;
                    this.RaiseDataMemberChanged("Name");
                }
            }
        }
    }
