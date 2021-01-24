            internal static bool CanConvertTo(this Type originType, Type destinationType)
            {
                if (originType == null)
                {
                    throw new ArgumentNullException("parameter originType is null");
                }
    
                if (destinationType == null)
                {
                    throw new ArgumentNullException("parameter destinationType is null");
                }
    
    
    #if !(NETSTANDARD1_3 || NETSTANDARD1_6)
                TypeConverter typeConverter = TypeDescriptor.GetConverter(originType);
    
                if (typeConverter.CanConvertTo(destinationType) == false)
                {
                    return false;
                }
    #endif
    
    
    #if NETSTANDARD1_3 || NETSTANDARD1_6
                try
                {
                    object tester;
                    tester = Convert.ChangeType(originType,destinationType);
                }
                catch
                {
                    return false;
                }
    #endif
    
                return true;
            }
