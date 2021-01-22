    using System;
    using System.Diagnostics;
    
    public class RefArray<TElem>
    {
      TElem[] data;
    
      /// <summary>Initializes RefArray by creating Ref&lt;T>[]data from values.</summary>
      public RefArray(TElem[] values)
      {
        data = values;
      }
    
      /// <summary>Creates reference RefArray pointing to same RefArray&lt;T> data.</summary>
      public RefArray(RefArray<TElem> references)
      {
        this.data = references.data;
      }
    
      public int Length
      {
        get { return data.Length; }
      }
    
      public TElem this[int index]
      {
        get
        {
          return data[index];
        }
        set
        {
          data[index] = value;
        }
      }
    }
    
    public static class RefArrayTest
    {
    
      public static void Usage()
      {
        
        // test ints (struct type)
        RefArray<int> c = new RefArray<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
        RefArray<int> d = new RefArray<int>(c);
        Debug.Print(string.Format("c[3]: {0,-30}, d[3]: {1}", c[3], d[3]));
        c[3] = 1111;
        Debug.Print(string.Format("c[3]: {0,-30}, d[3]: {1}", c[3], d[3]));
        d[3] = 2222;
        Debug.Print(string.Format("c[3]: {0,-30}, d[3]: {1}", c[3], d[3]));
        d[3] = c[3] + 3333;
        Debug.Print(string.Format("c[3]: {0,-30}, d[3]: {1}", c[3], d[3]));
    
        // test strings (class type)
        RefArray<string> a = new RefArray<string>(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
        RefArray<string> b = new RefArray<string>(a);
        Debug.Print(string.Format("a[3]: {0,-30}, b[3]: {1}", a[3], b[3]));
        a[3] = "set a";
        Debug.Print(string.Format("a[3]: {0,-30}, b[3]: {1}", a[3], b[3]));
        b[3] = "set b";
        Debug.Print(string.Format("a[3]: {0,-30}, b[3]: {1}", a[3], b[3]));
        a[3] = b[3] + " + take b set a";
        Debug.Print(string.Format("a[3]: {0,-30}, b[3]: {1}", a[3], b[3]));
    
        // proof of no point since
        string[] n1 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        string[] n2 = n1;
        Debug.Print(string.Format("n1[3]: {0,-30}, n2[3]: {1}", n1[3], n2[3]));
        n1[3] = "set n1";
        Debug.Print(string.Format("n1[3]: {0,-30}, n2[3]: {1}", n1[3], n2[3]));
        n2[3] = "set n2";
        Debug.Print(string.Format("n1[3]: {0,-30}, n2[3]: {1}", n1[3], n2[3]));
        n1[3] = n2[3] + " + take n2 set n1";
        Debug.Print(string.Format("n1[3]: {0,-30}, n2[3]: {1}", n1[3], n2[3]));
      }
    
    }
