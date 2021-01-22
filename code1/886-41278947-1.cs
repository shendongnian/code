    using System;
    
    /// <summary>
    /// would be same as EnumConstraint_T&lt;Enum>Parse&lt;EnumType>("Normal"),
    /// but writen like this it abuses constrain inheritence on System.Enum.
    /// </summary>
    public class EnumConstraint : EnumConstraint_T<Enum>
    {
    
    }
    
    /// <summary>
    /// provides ability to constrain TEnum to System.Enum abusing constrain inheritence
    /// </summary>
    /// <typeparam name="TClass">should be System.Enum</typeparam>
    public abstract class EnumConstraint_T<TClass>
      where TClass : class
    {
    
      public static TEnum Parse<TEnum>(string value)
        where TEnum : TClass
      {
        return (TEnum)Enum.Parse(typeof(TEnum), value);
      }
    
      public static bool TryParse<TEnum>(string value, out TEnum evalue)
        where TEnum : struct, TClass // struct is required to ignore non nullable type error
      {
        evalue = default(TEnum);
        return Enum.TryParse<TEnum>(value, out evalue);
      }
    
      public static TEnum TryParse<TEnum>(string value, TEnum defaultValue = default(TEnum))
        where TEnum : struct, TClass // struct is required to ignore non nullable type error
      {    
        Enum.TryParse<TEnum>(value, out defaultValue);
        return defaultValue;
      }
    
      public static TEnum Parse<TEnum>(string value, TEnum defaultValue = default(TEnum))
        where TEnum : struct, TClass // struct is required to ignore non nullable type error
      {
        TEnum result;
        if (Enum.TryParse<TEnum>(value, out result))
          return result;
        return defaultValue;
      }
    
      public static TEnum Parse<TEnum>(ushort value)
      {
        return (TEnum)(object)value;
      }
    
      public static sbyte to_i1<TEnum>(TEnum value)
      {
        return (sbyte)(object)Convert.ChangeType(value, typeof(sbyte));
      }
    
      public static byte to_u1<TEnum>(TEnum value)
      {
        return (byte)(object)Convert.ChangeType(value, typeof(byte));
      }
    
      public static short to_i2<TEnum>(TEnum value)
      {
        return (short)(object)Convert.ChangeType(value, typeof(short));
      }
    
      public static ushort to_u2<TEnum>(TEnum value)
      {
        return (ushort)(object)Convert.ChangeType(value, typeof(ushort));
      }
    
      public static int to_i4<TEnum>(TEnum value)
      {
        return (int)(object)Convert.ChangeType(value, typeof(int));
      }
    
      public static uint to_u4<TEnum>(TEnum value)
      {
        return (uint)(object)Convert.ChangeType(value, typeof(uint));
      }
    
    }
