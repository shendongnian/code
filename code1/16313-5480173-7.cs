    using System.ComponentModel;
    using System;
    
    namespace NMatrix
    {    
    	public sealed class MyEnum : RichEnum<int, MyEnum>
    	{
    		[Description("aap")]  public static readonly MyEnum my_aap   = new MyEnum(63000);
    		[Description("noot")] public static readonly MyEnum my_noot  = new MyEnum(63001);
    		[Description("mies")] public static readonly MyEnum my_mies  = new MyEnum(63002);
    
    		private MyEnum(int value) : base (value) { } 
    		public static implicit operator MyEnum(int value) { return Convert(value); }
    	}
    
    	public static class Program
    	{
    		public static void Main(string[] args)
    		{
     			foreach (var enumvalue in MyEnum.Values)
     				Console.WriteLine("MyEnum {0}: {1} ({2})", (int) enumvalue, enumvalue, enumvalue.Description);
    		}
    	}
    }
    
