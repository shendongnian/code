    using System;
    using nVentive.Umbrella.Validation;
    using nVentive.Umbrella.Extensions;
    
    namespace Namespace
    {
    	public static class StringValidationExtensionPoint
    	{
    		public static string Contains(this ValidationExtensionPoint<string> vep, string value)
    		{
    			if (vep.ExtendedValue.IndexOf(value, StringComparison.InvariantCultureIgnoreCase) == -1)
    				throw new ArgumentException(String.Format("Must contain '{0}'.", value));
    
    			return vep.ExtendedValue;
    		}
    	}
    
    	class Class
    	{
    		private string _foo;
    		public string Foo
    		{
    			set
    			{
    				_foo = value.Validation()
    					.NotNull("Foo")
    					.Validation()
    					.Contains("bar");
    			}
    		}
    	}
    }
