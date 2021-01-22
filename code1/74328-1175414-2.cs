    public class Settings : ApplicationSettingsBase
    {
        public Settings()
        {
            if (FixedBooks == null) FixedBooks = new BindingList<string>();
            FixedBooks.ListChanged += FixedBooks_ListChanged;
        }
        void FixedBooks_ListChanged(object sender, ListChangedEventArgs e)
        {
            this["FixedBooks"] = FixedBooks;
        }
        [UserScopedSetting()]
        public BindingList<string> FixedBooks
        {
            get { return (BindingList<string>)this["FixedBooks"]; }
            protected set { this["FixedBooks"] = value; }
        }
    }
