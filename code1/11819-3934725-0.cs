                Number = 1
            }
    
            public bool ReturnsFalse()
            {
                //The default value is not defined!
                return Enum.IsDefined(typeof (NoZero), default(NoZero));
            }
