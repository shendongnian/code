    namespace YourNameSpace
    {
        public partial class someClassName: ResourceDictionary
        {
            public someClassName()
            {
                InitializeComponent(); // you need this for the LoadComponent call on the Baml..
            }
        }
    }
