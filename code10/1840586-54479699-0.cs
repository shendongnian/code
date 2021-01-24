    public long QtdPed
        {
            get
            {
                if (_QtdPed == null)
                {
                    if (Mandatory && (QtdMin ?? 0) > 0)
                    {
                        _QtdPed = QtdMin;
                    }
                }
                return _QtdPed ?? 0;
            }
            set
            {
                _QtdPed = value;
                UpdatePrice();
            }
        }
        public void ChangeQtd(long value)
        {
            if (Mandatory || value > 0)
            {
                if (value < (QtdMin ?? 1))
                {
                    if (Mandatory && value == 0)
                    {
                        MessageBox.Show("Mandatory");
                    }
                    else
                    {
                        MessageBox.Show("Less than min (" + (QtdMin ?? 1) + ")...");
                    }
                    value = QtdMin ?? 1;
                }
            }
            QtdPed = value;
        }
