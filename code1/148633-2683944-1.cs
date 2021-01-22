     protected static TQuantity _Operator<TQuantity>(TQuantity lhs, TQuantity rhs,
                                           Func<double, double, double> op) 
           where TQuantity : QuantityConvertibleUnits<TFactory>, new()
     {  
            var toUnit = lhs.ConvertableUnit;  
            var equivalentRhs = _Convert<TQuantity>(rhs.Quantity, toUnit);  
            var newAmount = op(lhs.Quantity.Amount,equivalentRhs.Quantity.Amount);  
            return _Convert<TQuantity>(new Quantity(newAmount, toUnit.Unit), toUnit);  
      }  
