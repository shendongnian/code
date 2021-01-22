        Action myField;
        public event Action MyProperty
        {
            add { myField += value; }
            remove { myField -= value; }
        }
