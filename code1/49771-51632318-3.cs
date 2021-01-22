    var x1 = "123".ToInt(); //123
    var x2 = "abc".ToInt(); //0
    var x3 = "abc".ToIntNullable(); // (int?)null 
    int x4 = ((string)null).ToInt(-1); // -1
    int x5 = "abc".ToInt(-1); // -1
            
    var y = "19.50".ToDecimal(); //19.50
            
    var z1 = "invalid number string".ToDoubleNullable(); // (double?)null
    var z2 = "invalid number string".ToDoubleNullable(0); // (double?)0
