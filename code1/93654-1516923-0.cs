    switch (Type.GetTypeCode(type))
    {
    	case TypeCode.Boolean:
    	case TypeCode.Byte:
    	case TypeCode.Char:
    	case TypeCode.DBNull:
    	case TypeCode.DateTime:
    	case TypeCode.Decimal:
    	case TypeCode.Double:
    	case TypeCode.Empty:
    	case TypeCode.Int16:
    	case TypeCode.Int32:
    	case TypeCode.Int64:
    	case TypeCode.SByte:
    	case TypeCode.Single:
    	case TypeCode.String:
    	case TypeCode.UInt16:
    	case TypeCode.UInt32:
    	case TypeCode.UInt64:
    		break;
    	default:
    		if (type.GetType() != typeof(object))
    		{
    			throw new ArgumentException("invalid type.", "type");
    		}
    		break;
    }
