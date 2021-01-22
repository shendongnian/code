    class MyDateTime {
        public MyDateTime(DateTime dt) {
            _dt = dt;
        }
        public override String ToString() {
            return _dt.ToString("dd/MM/yyyy");
        }
        private DateTime _dt;
    }
