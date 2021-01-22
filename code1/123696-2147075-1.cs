    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace DSUPatternTest
    {
     [TestClass]
     public class DSUPatternPerformanceTest
     {
      public class Row
      {
       public int Qty;
       public string Name;
       public string Supplier;
       public string PrecomputedKey;
    
       public void ComputeKey()
       {
        // Do not need StringBuilder here, String.Concat does better job internally.
        PrecomputedKey =
         Qty.ToString().PadLeft(4, '0') + " "
         + Name.PadRight(12, ' ') + " "
         + Supplier.PadRight(12, ' ');
       }
    
       public bool Equals(Row other)
       {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return other.Qty == Qty && Equals(other.Name, Name) && Equals(other.Supplier, Supplier);
       }
    
       public override bool Equals(object obj)
       {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != typeof (Row)) return false;
        return Equals((Row) obj);
       }
    
       public override int GetHashCode()
       {
        unchecked
        {
         int result = Qty;
         result = (result*397) ^ (Name != null ? Name.GetHashCode() : 0);
         result = (result*397) ^ (Supplier != null ? Supplier.GetHashCode() : 0);
         return result;
        }
       }
      }
    
      public class RowComparer : IComparer<Row>
      {
       public int Compare(Row x, Row y)
       {
        int comparision;
        
        comparision = x.Qty.CompareTo(y.Qty);
                    if (comparision != 0) return comparision;
    
        comparision = x.Name.CompareTo(y.Name);
                    if (comparision != 0) return comparision;
    
        comparision = x.Supplier.CompareTo(y.Supplier);
    
        return comparision;
       }
      }
    
      [TestMethod]
      public void CustomLoopIsFaster()
      {
       var random = new Random();
       var rows = Enumerable.Range(0, 5000).Select(i =>
                 new Row
                  {
                   Qty = (int) (random.NextDouble()*9999),
                   Name = random.Next().ToString(),
         Supplier = random.Next().ToString()
    
                  }).ToList();
       
       foreach (var row in rows)
       {
        row.ComputeKey();
       }
    
       var dsuSw = Stopwatch.StartNew();
       var sortedByDSU = rows.OrderBy(i => i.PrecomputedKey).ToList();
       var dsuTime = dsuSw.ElapsedMilliseconds;
    
       var customSw = Stopwatch.StartNew();
       var sortedByCustom = rows.OrderBy(i => i, new RowComparer()).ToList();
       var customTime = customSw.ElapsedMilliseconds;
    
       Trace.WriteLine(dsuTime);
       Trace.WriteLine(customTime);
    
       CollectionAssert.AreEqual(sortedByDSU, sortedByCustom);
    
       Assert.IsTrue(dsuTime > customTime * 2.5);
      }
     }
    }
