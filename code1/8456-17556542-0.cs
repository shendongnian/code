        //C# code
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Reflection;
	using System.Security.Permissions;
	using System.Runtime.InteropServices;
	namespace JNIBridge
	{
		public class Temperature
		{
			[SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode | SecurityPermissionFlag.Assertion | SecurityPermissionFlag.Execution)]
			[ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
			[FileIOPermission(SecurityAction.Assert, Unrestricted = true)]
			
			public static double toFahrenheit(double value)
			{
				return (value * 9) / 5 + 32;
			}
			[SecurityPermission(SecurityAction.Assert, Flags = SecurityPermissionFlag.UnmanagedCode | SecurityPermissionFlag.Assertion | SecurityPermissionFlag.Execution)]
			[ReflectionPermission(SecurityAction.Assert, Unrestricted = true)]
			[FileIOPermission(SecurityAction.Assert, Unrestricted = true)]
			
			public static double toCelsius(double value)
			{
				return (value - 32) * 5 / 9; 
			}
			
		}
	}
