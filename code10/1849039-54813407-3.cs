    class MyViewModel 
    {
        private PhysicalValue _target;
        public PhysicalValueValidator TargetValidator { get; }
           
        public MyViewModel()
        { 
            _target = new PhysicalValue(5, 10);
            TargetValidator = new PhysicalValueValidator(_target);
            // update validation Logic...
            TargetValidator.SetMaxValue(6000);
        }
    }
