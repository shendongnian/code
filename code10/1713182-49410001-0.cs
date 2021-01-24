    public class GenericEntity : Entity 
    {
        private IList<string> _Values;
        public override IList<string> Values 
        {
            get { return _Values; }
            set 
                {
                    ValidateValues(value);
                    _Values = value;
                }    
            }
            private void ValidateValues(IList<string> values)
            {
                // many validation conditions here, if values validation fails, throws...
                this.OnValidateValues(values);
            }
            protected virtual void OnValidateValues(IList<string> values)
            {
                //do nothing.  Let sub-classes override.
            }
        }
    }
    public class AEntity : GenericEntity 
    {
        protected override void OnValidateValues(IList<string> values)
        {
            if(values.Count < 1) throw InvalidOperationException("values count!");
        }
    }
