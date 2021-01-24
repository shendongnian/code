            public enum Mask
            {
                IS_NONE = 0,
                IS_ONE = 1,
                IS_TWO = 2,
                IS_FOUR = 4,
                IS_EIGHT = 8,
                IS_SIXTEEN = 16
            }
            private static void Main()
            {
                byte data = 0x04;
                switch ((Mask)data)
                {
                    case Mask.IS_NONE :
                        break;
                    case Mask.IS_ONE :
                        break;
                    case Mask.IS_TWO :
                        break;
                    case Mask.IS_FOUR :
                        break;
                    case Mask.IS_EIGHT :
                        break;
                    case Mask.IS_SIXTEEN :
                        break;
                }
     
            }
