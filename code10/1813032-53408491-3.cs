    using System;
    namespace TestWpfApplication
    {
        public class Category
        {
            private int _code;
            private string _description;
            public event EventHandler CodeChanged;
            public int Code
            {
                get => _code;
                set
                {
                    if (_code != value)
                    {
                        _code = value;
                        OnCodeChanged();
                    }
                }
            }
            public string Description
            {
                get => _description;
                set => _description = value;
            }
            private void OnCodeChanged()
            {
                CodeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
