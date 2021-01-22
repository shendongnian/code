    class SampleControl {
            public Type EntityType{get;
            set
            {
                if(!value.Equals(typeof(Entity))
                  throw InvalidArgumentException(); 
                //assign
            }
        }
    }
