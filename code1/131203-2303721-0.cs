    interface IWantAssignmentNotification
    {
        void LostAssignment();
        void GainedAssignment();
    }
 
    class Ref<T> where T : IWantAssignmentNotification
    {
        private T _value;
        public T Value 
        {
            get { return _value; }
            set
            {
                if (_value != null)
                    _value.LostAssignment();
                _value = value;
                if (_value != null)
                    _value.GainedAssignment();                
            }
        }
    }
