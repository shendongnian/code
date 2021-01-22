		[StructLayout(LayoutKind.Sequential)]
		public struct WinModuleEntry:Toolhelp32.IEntry { // MODULEENTRY32
			[DllImport("kernel32.dll")]
			public static extern bool Module32Next(Toolhelp32.Snapshot snap, ref WinModuleEntry entry);
			public bool TryMoveNext(Toolhelp32.Snapshot snap, out Toolhelp32.IEntry entry) {
				var x = new WinModuleEntry { dwSize=Marshal.SizeOf(typeof(WinModuleEntry)) };
				var b = Module32Next(snap, ref x);
				entry=x;
				return b;
			}
			public int dwSize;
			public int th32ModuleID;
			public int th32ProcessID;
			public int GlblcntUsage;
			public int ProccntUsage;
			public IntPtr modBaseAddr;
			public int modBaseSize;
			public IntPtr hModule;
			//byte moduleName[256];
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string moduleName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string fileName;
			//byte fileName[260];
			//public const int sizeofModuleName = 256;
			//public const int sizeofFileName = 260;
		}
	---
	
	and some test .. 
		public class TestClass {
			public static void TestMethod() {
				var p = Process.GetCurrentProcess().Parent();
				Console.WriteLine("{0}", p.Id);
				var formatter = new CustomFormatter { };
				foreach(var x in Toolhelp32.CreateSnapshot<WinModuleEntry>(Toolhelp32.SnapModule, p.Id)) {
					Console.WriteLine(String.Format(formatter, "{0}", x));
				}
			}
		}
		public class CustomFormatter:IFormatProvider, ICustomFormatter {
			String ICustomFormatter.Format(String format, object arg, IFormatProvider formatProvider) {
				var type = arg.GetType();
				var fields = type.GetFields();
				var q = fields.Select(x => String.Format("{0}:{1}", x.Name, x.GetValue(arg)));
				return String.Format("{{{0}}}", String.Join(", ", q.ToArray()));
			}
			object IFormatProvider.GetFormat(Type formatType) {
				return typeof(ICustomFormatter)!=formatType ? null : this;
			}
		}
