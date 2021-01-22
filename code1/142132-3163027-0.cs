    private IDynamic ToExponential(Engine engine, Args args)
    {
        var x = engine.Context.ThisBinding.ToNumberPrimitive().Value;
    
        if (double.IsNaN(x))
        {
            return new StringPrimitive("NaN");
        }
    
        var s = "";
    
        if (x < 0)
        {
            s = "-";
            x = -x;
        }
    
        if (double.IsPositiveInfinity(x))
        {
            return new StringPrimitive(s + "Infinity");
        }
    
        var f = args[0].ToNumberPrimitive().Value;
        if (f < 0D || f > 20D)
        {
            throw new Exception("RangeError");
        }
    
        var m = "";
        var c = "";
        var d = "";
        var e = 0D;
        var n = 0D;
    
        if (x == 0D)
        {
            f = 0D;
            m = m.PadLeft((int)(f + 1D), '0');
            e = 0;
        }
        else
        {
            if (!args[0].IsUndefined) // fractionDigits is supplied
            {
                var lower = (int)Math.Pow(10, f);
                var upper = (int)Math.Pow(10, f + 1D);
                var min = 0 - 0.0001;
                var max = 0 + 0.0001; 
    
                for (int i = lower; i < upper; i++)
                {
                    for (int j = (int)f;; --j)
                    {
                        var result = i * Math.Pow(10, j - f) - x;
                        if (result > min && result < max)
                        {
                            n = i;
                            e = j;
                            goto Complete;
                        }
                        if (result <= 0)
                        {
                            break;
                        }
                    }
    
                    for (int j = (int)f + 1; ; j++)
                    {
                        var result = i * Math.Pow(10, j - f) - x;
                        if (result > min && result < max)
                        {
                            n = i;
                            e = j;
                            goto Complete;
                        }
                        if (result >= 0)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                var min = x - 0.0001;
                var max = x + 0.0001; 
    
                // Scan for f where f >= 0
                for (int i = 0;; i++)
                {
                    // 10 ^ f <= n < 10 ^ (f + 1)
                    var lower = (int)Math.Pow(10, i);
                    var upper = (int)Math.Pow(10, i + 1D);
                    for (int j = lower; j < upper; j++)
                    {
                        // n is not divisible by 10
                        if (j % 10 == 0)
                        {
                            continue;
                        }
    
                        // n must have f + 1 digits
                        var digits = 0;
                        var state = j;
                        while (state > 0)
                        {
                            state /= 10;
                            digits++;
                        }
                        if (digits != i + 1)
                        {
                            continue;
                        }
    
                        // Scan for e in both directions
                        for (int k = (int)i; ; --k)
                        {
                            var result = j * Math.Pow(10, k - i);
                            if (result > min && result < max)
                            {
                                f = i;
                                n = j;
                                e = k;
                                goto Complete;
                            }
                            if (result <= i)
                            {
                                break;
                            }
                        }
                        for (int k = (int)i + 1; ; k++)
                        {
                            var result = i * Math.Pow(10, k - i);
                            if (result > min && result < max)
                            {
                                f = i;
                                n = j;
                                e = k;
                                goto Complete;
                            }
                            if (result >= i)
                            {
                                break;
                            }
                        }
                    }
                }
            }
    
        Complete:
    
            m = n.ToString("G");
        }
    
        if (f != 0D)
        {
            m = m[0] + "." + m.Substring(1);
        }
    
        if (e == 0D)
        {
            c = "+";
            d = "0";
        }
        else
        {
            if (e > 0D)
            {
                c = "+";
            }
            else
            {
                c = "-";
                e = -e;
            }
            d = e.ToString("G");
        }
    
        m = m + "e" + c + d;
        return new StringPrimitive(s + m);
    }
