    public partial class Contact
    {
        public string RealFirstName
        {
           get { return this.FirstName.Trim(); }
           set { this.FirstName = value; }
        }
        ...
    }
