    class Validator
    {
        Func<bool> validatorDelegate;
        Action failDelegate;
        public Validator(Func<bool> v, Action fail)
        {
            validatorDelegate = v;
            failDelegate = fail;
        }
        public bool Validate()
        {
            bool rc = validatorDelegate();
            if (!rc) failDelegate();
            return rc;
        }
    }
    class ValidatorCollection : List<Validator>
    {
        Action successDelegate;
        Action failDelegate;
        public ValidatorCollection(Action failDelegate, Action successDelegate)
        {
            this.successDelegate = successDelegate;
            this.failDelegate = failDelegate;
        }
        public bool Validate()
        {
            var rc = this.All(x => x.Validate());
            if (rc) successDelegate();
            return rc;
        }
        public void Add(Func<bool> v)
        {
            this.Add(new Validator(v, failDelegate));
        }
    }
