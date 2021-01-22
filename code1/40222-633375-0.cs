using System;
using System.Collections.Generic;
namespace NullObjectPatternTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var items = new List<Item>
                            {
                                new Item(RateFactory.Create(20)),
                                new Item(RateFactory.Create(0))
                            };
            PrintPricesForItems(items);
        }
        private static void PrintPricesForItems(IEnumerable<Item> items)
        {
            foreach (var item in items)
                Console.WriteLine("Item Price: {0:C}", item.GetPrice());
        }
    }
    public abstract class ItemBase
    {
        public abstract Rate Rate { get; }
        public int GetPrice()
        {
            // There is NO need to check if Rate == 0 or Rate == null
            return 1 * Rate.Value;
        }
    }
    public class Item : ItemBase
    {
        private readonly Rate _Rate;
        public override Rate Rate { get { return _Rate; } }
        public Item(Rate rate) { _Rate = rate; }
    }
    public sealed class RateFactory
    {
        public static Rate Create(int rateValue)
        {
            if (rateValue == 0) 
                return new NullRate();
            return new Rate(rateValue);
        }
    }
    public class Rate
    {
        public int Value { get; set; }
        public virtual bool HasValue { get { return (Value > 0); } }
        public Rate(int value) { Value = value; }
    }
    public class NullRate : Rate
    {
        public override bool HasValue { get { return false; } }
        public NullRate() : base(0) { }
    }
}
