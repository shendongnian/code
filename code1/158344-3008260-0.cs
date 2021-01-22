        /**
        * <summary>
        *   This function converts a WMI CimType to a System.Type
        *   It was copied from: http://www.devcow.com/blogs/adnrg/archive/2005/09/23/108.aspx
        * </summary>
        */
        private static System.Type ConvertCimType(PropertyData property)
        {
            System.Type tReturnVal = null;
            switch (property.Type )
            {
                case CimType.Boolean:
                    tReturnVal = typeof(System.Boolean);
                    break;
                case CimType.Char16:
                    tReturnVal = typeof(System.String);
                    break;
                case CimType.DateTime:
                    tReturnVal = typeof(System.DateTime);
                    break;
                case CimType.Object:
                    tReturnVal = typeof(System.Object);
                    break;
                case CimType.Real32:
                    tReturnVal = typeof(System.Decimal);
                    break;
                case CimType.Real64:
                    tReturnVal = typeof(System.Decimal);
                    break;
                case CimType.Reference:
                    tReturnVal = typeof(System.Object);
                    break;
                case CimType.SInt16:
                    tReturnVal = typeof(System.Int16);
                    break;
                case CimType.SInt32:
                    tReturnVal = typeof(System.Int32);
                    break;
                case CimType.SInt8:
                    tReturnVal = typeof(System.SByte);
                    break;
                case CimType.String:
                    tReturnVal = typeof(System.String);
                    break;
                case CimType.UInt16:
                    tReturnVal = typeof(System.UInt16);
                    break;
                case CimType.UInt32:
                    tReturnVal = typeof(System.UInt32);
                    break;
                case CimType.UInt64:
                    tReturnVal = typeof(System.UInt64);
                    break;
                case CimType.UInt8:
                    tReturnVal = typeof(System.Byte);
                    break;
            }
            // do a final check
            tReturnVal = CheckType(property, tReturnVal);
            return tReturnVal;
        }
        private static System.Type CheckType(PropertyData property, System.Type itemType)
        {
            if (property.IsArray)
            {
                return System.Type.GetType( itemType.ToString() + "[]" );
            }
            else
            {
                return itemType;
            }
        }
