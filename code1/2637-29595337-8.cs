    class Mediator
    {
        public delegate void PersonChangedDelegate(Person p); //delegate type definition
        public static PersonChangedDelegate PersonChangedDel; //delegate instance. Detail view will "subscribe" to this.
        public static void OnPersonChanged(Person p) //Form1 will call this when the drop-down changes.
        {
            if (PersonChangedDel != null)
            {
                PersonChangedDel(p);
            }
        }
    }
