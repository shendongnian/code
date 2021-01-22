    class TheForm: Form
    {
        private static TheForm Instance;
        private TheForm() // Constructor is private
        {
        }
        public static Show(Form mdiParent)
        {
            if ( Instance == null )
            {
                // Create new form, assign it to Instance
            }
            else
                Instance.Activate(); // Not sure about this line, find the appropriate equivalent yourself.
        }
        protected override OnFormClose(EventArgs e)
        {
            Instance = null;
            base.OnFormClose(e);
        }
    }
