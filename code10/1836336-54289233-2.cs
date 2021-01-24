    public MyBaseType IdentifyCorrectType()
        {
            var identifyingCondition = GetCorrectType();// returns 1,2,3...
            switch (identifyingCondition)
            {
                case 1:
                    return new MyType1();
                case 2:
                    return new MyType2();
                case 3:
                    return new MyType3();
                default:
                    return null;
            }
        }
