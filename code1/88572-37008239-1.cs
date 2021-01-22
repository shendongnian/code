    using System;
    using System.Text;
    using System.Diagnostics;
    
    public class Ref_T<TValue>
    {  
      public TValue data;
      public Ref_T(TValue value)
      {
        this.data = value;
      }
    }
    
    public class RefArray<TElem>
    {
      public readonly Ref_T<TElem>[] data;
    
      /// <summary>Initializes RefArray by creating Ref&lt;T>[]data from values.</summary>
      public RefArray(TElem[] values)
      {
        data = new Ref_T<TElem>[values.Length];
        for (int i = 0; i < values.Length; i++)
        {
          // creates reference members
          data[i] = new Ref_T<TElem>(values[i]); 
        }
      }
    
      /// <summary>Creates reference RefArray pointing to same RefArray&lt;T> data.</summary>
      public RefArray(RefArray<TElem> references)
      {
        data = references.data;
      }
    
      /// <summary>Creates reference RefArray pointing to same Ref&lt;T>[] references.</summary>
      public RefArray(Ref_T<TElem>[] references)
      {
        data = references;
      }
    
      public int Length
      {
        get { return data.Length; }
      }
    
      public TElem this[int index]
      {
        get { return data[index].data; }
        set { data[index].data = value; }
      }
    
      public override string ToString()
      {
        StringBuilder sb = new StringBuilder();
        int count = data.Length;
        for (int i = 0; i < count; i++ )
          sb.Append(string.Format("[{0}]:{1,-4}, ", i, data[i].data));
        return sb.ToString();
      }
    
      public static implicit operator Array(RefArray<TElem> a)
      {
        return a.data;
      }
    }
    
    public static class RefArrayTest
    {
    
      public static void Usage()
      {    
        // test ints (struct type) out of order
        // initialize 
        RefArray<int> e = new RefArray<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
        // reference e out of order
        RefArray<int> f = new RefArray<int>(new Ref_T<int>[] 
          { e.data[8], e.data[6], e.data[4], e.data[2], e.data[0], 
            e.data[9], e.data[7], e.data[5], e.data[3], e.data[1] 
          });
    
        Debug.WriteLine("Initial: ");
        Debug.WriteLine("e: [" + e + "]");
        Debug.WriteLine("f: [" + f + "]\r\n");
        
        e[3] = 1111;
        Debug.WriteLine("e[3] = 1111;");
        Debug.WriteLine("e: [" + e + "]");
        Debug.WriteLine("f: [" + f + "]\r\n");
        
        f[3] = 2222;
        Debug.WriteLine("f[3] = 2222;");
        Debug.WriteLine("e: [" + e + "]");
        Debug.WriteLine("f: [" + f + "]\r\n");
    
        f[3] = e[3] + 3333;
        Debug.WriteLine("f[3] = e[3] + 3333;");
        Debug.WriteLine("e: [" + e + "]");
        Debug.WriteLine("f: [" + f + "]\r\n");
    
        Array.Reverse(f);
        Debug.WriteLine("Array.Reverse(f);");
        Debug.WriteLine("e: [" + e + "]");
        Debug.WriteLine("f: [" + f + "]\r\n");
      }
    
    }
