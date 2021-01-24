    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
    
    
        class Program
        {
    
            static void Main(string[] args)
            {
                List<Numbers> bills = new List<Numbers>();
                List<Numbers> cars = new List<Numbers>();
    
                bills.Add(new Bill("ABC", "123"));
                bills.Add(new Bill("ABC", "654"));
                bills.Add(new Bill("WER", "123"));
                bills.Add(new Bill("ABC", "375"));
                bills.Add(new Bill("ABC", "762"));
                bills.Add(new Bill("WER", "792"));
                bills.Add(new Bill("DDR", "123"));
                bills.Add(new Bill("DEF", "123"));
                bills.Add(new Bill("DEF", "045"));
                bills.Add(new Bill("OLY", "123"));
                bills.Add(new Bill("ABC", "342"));
                bills.Add(new Bill("QWE", "874"));
                bills.Add(new Bill("ABC", "986"));
                bills.Add(new Bill("OLY", "123"));
                bills.Add(new Bill("QWE", "123"));
                bills.Add(new Bill("QWE", "143"));
    
                CarBillComparer cb = new CarBillComparer();
    
                cars.Add(new Car("ABC", "375"));
                cars.Add(new Car("QWE", "874"));
                cars.Add(new Car("ABC", "762"));
    
                bills.Sort(cb);
                cars.Sort(cb);
    
                List<Numbers> returnBills = new List<Numbers>();
    
                int index = 0;
    
                foreach (Car onecar in cars)
                {
                    int count = bills.Count - index;
                    index = bills.BinarySearch(index, count, onecar, cb);
                    if (index > -1)
                    {
                        //Item found
                        returnBills.Add(bills[index]);
                    }
                    else
                    {
                        index = ~index;
                    }
                }
    
            }
            public class CarBillComparer : IComparer<Numbers>
            {
                public int Compare(Numbers x, Numbers y)
                {
                    int compResult = x.car_init.CompareTo(y.car_init);
                    if (compResult == 0)
                    {
                        compResult = x.car_nbr.CompareTo(y.car_nbr);
                    }
                    return compResult;
                }
            }
    
            public interface Numbers
            {
                string car_init { get; }
                string car_nbr { get; }
            }
    
            public class Bill:Numbers
            {
                public Bill(string car_init, string car_nbr)
                {
                    this.car_init = car_init;
                    this.car_nbr = car_nbr;
                }
    
                public string car_init { get; }
                public string car_nbr { get; }
            }
    
            public class Car : Numbers
            {
                public Car(string car_init, string car_nbr)
                {
                    this.car_init = car_init;
                    this.car_nbr = car_nbr;
                }
    
                public string car_init { get; }
                public string car_nbr { get; }
            }
    
           
        }
    }
