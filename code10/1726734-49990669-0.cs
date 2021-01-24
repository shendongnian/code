    // 
    // Version 2
    // 
    class TimerExample_V2 {
        private DateTime    _TimeNow = System.DateTime.Now;
        private DateTime    _PreTime = System.DateTime.Now;
        private string      _format = "t";
        private string      _cultureName = "en-US";
    
        public TimerExample_V2() {
            CultureInfo culture = new CultureInfo(_cultureName);
            CultureInfo.CurrentCulture = culture;
        }
    
        public void UpdateCurrentTimeUI() {
            _TimeNow = System.DateTime.Now;
    
            if(_PreTime.Minute != _TimeNow.Minute) {
                // Note: this case appear only once per minute.
                _PreTime = System.DateTime.Now;
                string newText = _TimeNow.ToString(_format);
                //m_Text_Time.text = newText; // Update unity display
                // I omit this display unity. (Same cost in both case)
            }
        }
