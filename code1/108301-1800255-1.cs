        private int? _Value;
        private bool _ValueCanBeUsed = false;
        public int? Value
        {
            get { return this._Value; }
            set
            {
                this._Value = value;
                this._ValueCanBeUsed = true;
            }
        }
        public bool DoSomethingTerrible(out int? value)
        {
            if (this._ValueCanBeUsed)
            {
                value = this._Value;
                // prevent others from using this value until it has been set again
                this._ValueCanBeUsed = false;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
