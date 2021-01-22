    /// <summary>
    /// Specifies when ToCsv() should return null.  Refer to ToCsv() for IEnumerable[T]
    /// </summary>
    public enum ReturnNullCsv
    {
        /// <summary>
        /// Return String.Empty when the input list is null or empty.
        /// </summary>
        Never,
    
        /// <summary>
        /// Return null only if input list is null.  Return String.Empty if list is empty.
        /// </summary>
        WhenNull,
            
        /// <summary>
        /// Return null when the input list is null or empty
        /// </summary>
        WhenNullOrEmpty,
    
        /// <summary>
        /// Throw if the argument is null
        /// </summary>
        ThrowIfNull
    }   
    /// <summary>
    /// Converts IEnumerable list of values to a comma separated string values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values">The values.</param>        
    /// <param name="joinSeparator"></param>
    /// <returns>System.String.</returns>
    public static string ToCsv<T>(
        this IEnumerable<T> values,            
        string joinSeparator = ",")
    {
        return ToCsvOpt<T>(values, null /*selector*/, ReturnNullCsv.ThrowIfNull, joinSeparator);
    }
    
    /// <summary>
    /// Converts IEnumerable list of values to a comma separated string values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values">The values.</param>
    /// <param name="selector">An optional selector</param>
    /// <param name="joinSeparator"></param>
    /// <returns>System.String.</returns>
    public static string ToCsv<T>(
        this IEnumerable<T> values,
        Func<T, string> selector,            
        string joinSeparator = ",") 
    {
        return ToCsvOpt<T>(values, selector, ReturnNullCsv.ThrowIfNull, joinSeparator);
    }
    
    /// <summary>
    /// Converts IEnumerable list of values to a comma separated string values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values">The values.</param>
    /// <param name="returnNullCsv">Return mode (refer to enum ReturnNullCsv).</param>
    /// <param name="joinSeparator"></param>
    /// <returns>System.String.</returns>
    public static string ToCsvOpt<T>(
        this IEnumerable<T> values,
        ReturnNullCsv returnNullCsv = ReturnNullCsv.Never,
        string joinSeparator = ",")
    {
        return ToCsvOpt<T>(values, null /*selector*/, returnNullCsv, joinSeparator);
    }
    
    /// <summary>
    /// Converts IEnumerable list of values to a comma separated string values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="values">The values.</param>
    /// <param name="selector">An optional selector</param>
    /// <param name="returnNullCsv">Return mode (refer to enum ReturnNullCsv).</param>
    /// <param name="joinSeparator"></param>
    /// <returns>System.String.</returns>
    public static string ToCsvOpt<T>(
        this IEnumerable<T> values, 
        Func<T, string> selector,
        ReturnNullCsv returnNullCsv = ReturnNullCsv.Never,
        string joinSeparator = ",")
    {
        switch (returnNullCsv)
        {
            case ReturnNullCsv.Never:
                if (!values.AnyOpt())
                    return string.Empty;
                break;
    
            case ReturnNullCsv.WhenNull:
                if (values == null)
                    return null;
                break;
    
            case ReturnNullCsv.WhenNullOrEmpty:
                if (!values.AnyOpt())
                    return null;
                break;
    
            case ReturnNullCsv.ThrowIfNull:
                if (values == null)
                    throw new ArgumentOutOfRangeException("ToCsvOpt was passed a null value with ReturnNullCsv = ThrowIfNull.");
                break;
    
            default:
                throw new ArgumentOutOfRangeException("returnNullCsv", returnNullCsv, "Out of range.");
        }
                
        if (selector == null)
        {
            if (typeof(T) == typeof(Int16) || 
                typeof(T) == typeof(Int32) || 
                typeof(T) == typeof(Int64))
            {                   
                selector = (v) => Convert.ToInt64(v).ToStringInvariant();
            }
            else if (typeof(T) == typeof(decimal))
            {
                selector = (v) => Convert.ToDecimal(v).ToStringInvariant();
            }
            else if (typeof(T) == typeof(float) ||
                    typeof(T) == typeof(double))
            {
                selector = (v) => Convert.ToDouble(v).ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                selector = (v) => v.ToString();
            }            
        }
    
        return String.Join(joinSeparator, values.Select(v => selector(v)));
    }
    
    public static string ToStringInvariantOpt(this Decimal? d)
    {
        return d.HasValue ? d.Value.ToStringInvariant() : null;
    }
            
    public static string ToStringInvariant(this Decimal d)
    {
        return d.ToString(CultureInfo.InvariantCulture);
    }
                 
    public static string ToStringInvariantOpt(this Int64? l)
    {
        return l.HasValue ? l.Value.ToStringInvariant() : null;
    }
    
    public static string ToStringInvariant(this Int64 l)
    {
        return l.ToString(CultureInfo.InvariantCulture);
    }
    
    public static string ToStringInvariantOpt(this Int32? i)
    {
        return i.HasValue ? i.Value.ToStringInvariant() : null;
    }
            
    public static string ToStringInvariant(this Int32 i)
    {
        return i.ToString(CultureInfo.InvariantCulture);
    }
    
    public static string ToStringInvariantOpt(this Int16? i)
    {
        return i.HasValue ? i.Value.ToStringInvariant() : null;
    }
    
    public static string ToStringInvariant(this Int16 i)
    {
        return i.ToString(CultureInfo.InvariantCulture);
    }
