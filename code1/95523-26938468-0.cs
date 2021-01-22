    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace concat
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] x = new int [] { 1, 2, 3};
                int[] y = new int [] { 4, 5 };
                
                
                int itter = 50000;
                Console.WriteLine("test iterations: {0}", itter);
    
                DateTime startTest = DateTime.Now;
                for(int  i = 0; i < itter; i++)
                {
                    int[] z;
                    z = x.Concat(y).ToArray();
                }
                Console.WriteLine ("Concat Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks );
    
                startTest = DateTime.Now;
                for(int  i = 0; i < itter; i++)
                {
                    var vz = new int[x.Length + y.Length];
                    x.CopyTo(vz, 0);
                    y.CopyTo(vz, x.Length);
                }
                Console.WriteLine ("CopyTo Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks );
    
                startTest = DateTime.Now;
                for(int  i = 0; i < itter; i++)
                {
                    List<int> list = new List<int>();
                    list.AddRange(x);
                    list.AddRange(y);
                    int[] z = list.ToArray();
                }
                Console.WriteLine("list.AddRange Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    int[] z = Methods.Concat(x, y);
                }
                Console.WriteLine("Concat(x, y) Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    int[] z = Methods.ConcatArrays(x, y);
                }
                Console.WriteLine("ConcatArrays Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    int[] z = Methods.SSConcat(x, y);
                }
                Console.WriteLine("SSConcat Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int k = 0; k < itter; k++)
                {
                    int[] three = new int[x.Length + y.Length];
    
                    int idx = 0;
    
                    for (int i = 0; i < x.Length; i++)
                        three[idx++] = x[i];
                    for (int j = 0; j < y.Length; j++)
                        three[idx++] = y[j];
                }
                Console.WriteLine("Roll your own Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    int[] z = Methods.ConcatArraysLinq(x, y);
                }
                Console.WriteLine("ConcatArraysLinq Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    int[] z = Methods.ConcatArraysLambda(x, y);
                }
                Console.WriteLine("ConcatArraysLambda Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    List<int> targetList = new List<int>(x);
                    targetList.Concat(y);
                }
                Console.WriteLine("targetList.Concat(y) Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
    
                startTest = DateTime.Now;
                for (int i = 0; i < itter; i++)
                {
                    int[] result = x.ToList().Concat(y.ToList()).ToArray();
                }
                Console.WriteLine("x.ToList().Concat(y.ToList()).ToArray() Test Time in ticks: {0}", (DateTime.Now - startTest).Ticks);
            }
        }
        static class Methods
        {
            public static T[] Concat<T>(this T[] x, T[] y)
            {
                if (x == null) throw new ArgumentNullException("x");
                if (y == null) throw new ArgumentNullException("y");
                int oldLen = x.Length;
                Array.Resize<T>(ref x, x.Length + y.Length);
                Array.Copy(y, 0, x, oldLen, y.Length);
                return x;
            }
    
            public static T[] ConcatArrays<T>(params T[][] list)
            {
                var result = new T[list.Sum(a => a.Length)];
                int offset = 0;
                for (int x = 0; x < list.Length; x++)
                {
                    list[x].CopyTo(result, offset);
                    offset += list[x].Length;
                }
                return result;
            }
    
    
            public static T[] SSConcat<T>(this T[] first, params T[][] arrays)
            {
                int length = first.Length;
                foreach (T[] array in arrays)
                {
                    length += array.Length;
                }
                T[] result = new T[length];
                length = first.Length;
                Array.Copy(first, 0, result, 0, first.Length);
                foreach (T[] array in arrays)
                {
                    Array.Copy(array, 0, result, length, array.Length);
                    length += array.Length;
                }
                return result;
            }
    
            public static T[] ConcatArraysLinq<T>(params T[][] arrays)
            {
                return (from array in arrays
                        from arr in array
                        select arr).ToArray();
            }
    
            public static T[] ConcatArraysLambda<T>(params T[][] arrays)
            {
                return arrays.SelectMany(array => array.Select(arr => arr)).ToArray();
            }
        }
    
    }
