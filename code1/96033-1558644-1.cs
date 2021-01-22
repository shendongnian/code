    public class Employee
    {
        private bool _isRetired;
        private double _amount;
        public double GetPayAmount()
        {
             if (_isRetired)
                return _amount * 0.9;
             else
                return _amount;
        }
    }
