    using System;
    
    namespace ExponentialOperator
    {
        /// <summary>
        /// Double class that uses ^ as exponential operator
        /// </summary>
        public class DoubleX
        {
            #region ---------------- Fields ----------------
    
            private readonly double _value;
    
            #endregion ------------- Fields ----------------
    
            #region -------------- Properties --------------
    
            public double Value
            {
                get { return _value; }
            }
    
            #endregion ----------- Properties --------------
    
            #region ------------- Constructors -------------
    
            public DoubleX(double value)
            {
                _value = value;
            }
    
            public DoubleX(int value)
            {
                _value = Convert.ToDouble(value);
            }
    
            #endregion ---------- Constructors -------------
    
            #region --------------- Methods ----------------
    
            public override string ToString()
            {
                return _value.ToString();
            }
    
            #endregion ------------ Methods ----------------
    
            #region -------------- Operators ---------------
    
            // Change the ^ operator to be used for exponents.
    
            public static DoubleX operator ^(DoubleX value, DoubleX exponent)
            {
                return Math.Pow(value, exponent);
            }
    
            public static DoubleX operator ^(DoubleX value, double exponent)
            {
                return Math.Pow(value, exponent);
            }
    
            public static DoubleX operator ^(double value, DoubleX exponent)
            {
                return Math.Pow(value, exponent);
            }
    
            public static DoubleX operator ^(DoubleX value, int exponent)
            {
                return Math.Pow(value, exponent);
            }
    
            #endregion ----------- Operators ---------------
    
            #region -------------- Converters --------------
    
            // Allow implicit convertion
    
            public static implicit operator DoubleX(double value)
            {
                return new DoubleX(value);
            }
    
            public static implicit operator DoubleX(int value)
            {
                return new DoubleX(value);
            }
    
            public static implicit operator Double(DoubleX value)
            {
                return value._value;
            }
    
            #endregion ----------- Converters --------------
        }
    }
