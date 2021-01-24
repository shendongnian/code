    using System;
    
    namespace PlayAreaCSCon
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var d = new MoneyQuantity<Dollar>(1);
    			var p = new MoneyQuantity<PoundSterling>(1);
    
    			Console.WriteLine(p.CompareTo(d));
    		}
    	}
    	public abstract class Currency
    	{
    		protected Currency() { }
    	}
    	public class Dollar : Currency
    	{
    		public Dollar() : base() { }
    	}
    	public class PoundSterling : Currency
    	{
    		public PoundSterling() : base() { }
    	}
    	public struct MoneyQuantity<TCurrency> : 
               IComparable<MoneyQuantity<TCurrency>>
               where TCurrency : Currency, new()
    	{
    		public decimal Amount { get; }
    
    		public MoneyQuantity(decimal amount)
    		{
    			Amount = amount;
    		}
    
    		public int CompareTo(MoneyQuantity<TCurrency> that)
    				=> Amount.CompareTo(that.Amount);
    	}
    }
