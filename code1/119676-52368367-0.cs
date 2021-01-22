	using System;
	using System.Collections.Generic;
	using System.Text;
	using RGiesecke.DllExport;
	using System.Runtime.InteropServices;
	namespace DelphiNET
	{
		[ComVisible(true)]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("BA7DFB53-6CEC-4ADA-BE5E-16F1A46DFAC5")]
		public interface IDotNetAdder
		{
			int Add3(int left);
			int Mult3(int left);
			string Expr3(string palavra);
		}
		[ComVisible(true)]
		[ClassInterface(ClassInterfaceType.None)]
		public class DotNetAdder : DelphiNET.IDotNetAdder
		{
			public int Add3(int left)
			{
				return left + 3;
			}
			public int Mult3(int left)
			{
				return left * 3;
			}
			public string Expr3(string palavra)
			{
				return palavra + " é a palavra que estou esperando!";
			}
		}
		internal static class UnmanagedExports
		{
			[DllExport("createdotnetadder", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
			static void CreateDotNetAdderInstance([MarshalAs(UnmanagedType.Interface)]out IDotNetAdder instance)
			{
				instance = new DotNetAdder();
			}
		}
	}
