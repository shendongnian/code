    namespace YourNamespace
    {
        class MyUserControl : UserControl
        {
            // it needs to be here:
            public event EventHandler LabelsTextChanged;
            
            ...
        }
    }
