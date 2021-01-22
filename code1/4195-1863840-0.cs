    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            
             Dictionary<object,object > d = p.Dic<object, object>("Age",32,"Height",177,"wrest",36);//(un)comment
             //Dictionary<object, object> d = p.Dic<object, object>();//(un)comment
            
            foreach(object o in d)
            {
                Console.WriteLine(" {0}",o.ToString());
            }
            Console.ReadLine();
        }
        public Dictionary<K, V> Dic<K, V>(params object[] data)
        {
            
           // if (data.Length == 0 || data == null || data.Length % 2 != 0) return null;
            if (data.Length == 0 || data == null || data.Length % 2 != 0) return new Dictionary<K,V>(1){{ (K)new Object(),(V)new object()}};
            
            Dictionary<K, V> dc = new Dictionary<K, V>(data.Length/2);
            int i=0;
            while(i < data.Length)
            {
                dc.Add((K)data[i],(V)data[++i]);
                i++;
            }
            return dc;
        
        }
    }
}
