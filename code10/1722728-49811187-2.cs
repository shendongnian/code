    protected override IEnumerable<int> InternalRun(IEnumerable<int> values, int digit)
    {
       var ary = values.ToArray();
       var result = new List<int>();
       fixed (int* pAry = ary)
       {
          for (var p = pAry; p < pAry + ary.Length; p++)
             for (var d = *p; d > 0; d /= 10)
                if (d % 10 == digit){ result.Add(*p); break;}
       }  
    }
    
    protected override IEnumerable<int> InternalRun(IEnumerable<int> values, int digit)
    {
       foreach (var val in values)
          for (var d = val; d > 0; d /= 10)
             if (d % 10 == digit)
                yield return val;
    }
