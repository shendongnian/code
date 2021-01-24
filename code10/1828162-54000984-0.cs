        public bool TooYoung { get; set; }
        private DateTime _DateSelected;
        public DateTime DateSelected
        {
            get { return _DateSelected; }
            set
            {
                if (_DateSelected.Equals(value))
                {
                    return;
                }
                
                _DateSelected = value;
                // check someone is too young or not
                var age = CalculateAge(_DateSelected);
                TooYoung = age <= 15;
            }
        }
        private int CalculateAge(DateTime birthDay)
        {
            int years = DateTime.Now.Year - birthDay.Year;
            if ((birthDay.Month > DateTime.Now.Month) || (birthDay.Month == DateTime.Now.Month && birthDay.Day > DateTime.Now.Day))
                years--;
            return years;
        }
