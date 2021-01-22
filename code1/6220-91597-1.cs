            System.Type propertyType = typeof(Boolean);
            System.TypeCode typeCode = Type.GetTypeCode(propertyType);
            switch (typeCode)
            {
                case TypeCode.Boolean:
                    //doStuff
                    break;
                case TypeCode.String:
                    //doOtherStuff
                    break;
                default: break;
            }
