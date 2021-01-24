        public int ShirtNo
        {
            get { return _shirtNo;  }
            set
            {
                if (shirtNumbers.Contains(value) == false)
                {
                    _shirtNo = value;
                    AddToList(value)
                }
                else
                {
                    _shirtNo = 0;
                }
            }
        }
