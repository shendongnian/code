    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace so_listobj
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<O> anOList = new List<O>();
                List<List<O>> aGroupOList = new List<List<O>>();
    
                anOList.Add(new O(1, 7));
                anOList.Add(new O(1, 7));
                anOList.Add(new O(2, 2));
                anOList.Add(new O(2, 2));
                anOList.Add(new O(2, 14));
                anOList.Add(new O(2, 14));
    
                Console.Out.WriteLine("Initial state");
    
                foreach (O o in anOList)
                {
                    Console.Out.WriteLine(o);
                }
    
                var grp =
                    from o in anOList
                    group o by o.Date into a
                    select new {Date = a.Key, aGroupOList = a  };
    
                Console.Out.WriteLine("after grouping");
    
                foreach (var _ob in grp)
                {
                    foreach (var _anotherOList in _ob.aGroupOList)
                    {
                        Console.Out.WriteLine("{0} {1}", _ob.Date, _anotherOList.ToString());
                    }
                }
            }
        }
    
    
        class O
        {
            private int  _Odate;
            private int _Oduration;
    
            public O(int date, int duration)
            {
                _Odate = date;
                _Oduration = duration;
            }
    
            public int Date
            {
                get { return _Odate; }
                set { _Odate = value; }
            }
            public int Duration
            {
                get { return _Oduration; }
                set { _Oduration = value; }
            }
    
            
            public override String ToString()
            {
                return String.Format("- Date :{0}\t Duration:{1}", _Odate, _Oduration);
            }
        }
    }
