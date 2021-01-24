    public InputModel
    {
        int Id {get; set;}
        private bool istrue;
        bool? Istrue
        {
            get
            {
                return istrue;
            }
            set
            {
                if (value.GetType() == typeof(bool))
                {
                    istrue = value;
                }
                else
                {
                    istrue = false;
                }
            }
        }
    }
