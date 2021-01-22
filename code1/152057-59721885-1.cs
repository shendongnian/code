	using System.IO;
	using EnvDTE;
	using DTEProcess = EnvDTE.Process;
	using System;
	using System.Collections.Generic;
	using Process = System.Diagnostics.Process;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	namespace AppController {
		#region Classes
		/// <summary>Visual Studio attacher.</summary>
		public static class VSAttacher {
			public static Action<object> log = (o) => Console.WriteLine(o);
		
			//Change following variables depending on your version of visual studio
			//public static string VSProcessName = "WDExpress";
			//public static string VSObjectName = "!WDExpress";
			public static string VSProcessName = "devenv";
			public static string VSObjectName = "!VisualStudio";
			/// <summary>
			/// Tries to attach the program to Visual Studio debugger.
			/// Returns true is the attaching was successful, false is debugger attaching failed.
			/// </summary>
			/// <param name="sln">Solution file containing code to be debugged.</param>
			public static bool attachDebugger(string sln) {
				if (System.Diagnostics.Debugger.IsAttached) return true;
				log("Attaching to Visual Studio debugger...");
				var proc = VSAttacher.GetVisualStudioForSolutions(
					new List<string>() { Path.GetFileName(sln) });
				if (proc != null) VSAttacher.AttachVSToProcess(
						proc, Process.GetCurrentProcess());
				else { 
					try { System.Diagnostics.Debugger.Launch(); }
					catch (Exception e) { }
				} // try and attach the old fashioned way
				if (System.Diagnostics.Debugger.IsAttached) {
					log(@"The builder was attached successfully. Further messages will displayed in ""Debug"" output of ""Output"" window.");
					return true;
				}
				log("Could not attach to visual studio instance.");
				return false;
			}
			#region Public Methods
			#region Imports
			[DllImport("User32")]
			private static extern int ShowWindow(int hwnd, int nCmdShow);
			/// <summary>Returns a pointer to an implementation of <see cref="IBindCtx"/> (a bind context object). This object stores information about a particular moniker-binding operation.</summary>
			/// <param name="reserved">This parameter is reserved and must be 0.</param>
			/// <param name="ppbc">Address of an <see cref="IBindCtx"/>* pointer variable that receives the interface pointer to the new bind context object. When the function is successful, the caller is responsible for calling Release on the bind context. A NULL value for the bind context indicates that an error occurred.</param>
			/// <returns></returns>
			[DllImport("ole32.dll")]
			public static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);
			/// <summary>Returns a pointer to the <see cref="IRunningObjectTable"/> interface on the local running object table (ROT).</summary>
			/// <param name="reserved">This parameter is reserved and must be 0.</param>
			/// <param name="prot">The address of an IRunningObjectTable* pointer variable that receives the interface pointer to the local ROT. When the function is successful, the caller is responsible for calling Release on the interface pointer. If an error occurs, *pprot is undefined.</param>
			/// <returns>his function can return the standard return values E_UNEXPECTED and S_OK.</returns>
			[DllImport("ole32.dll")]
			public static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			public static extern bool SetForegroundWindow(IntPtr hWnd);
			[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			public static extern IntPtr SetFocus(IntPtr hWnd);
			#endregion
			public static string GetSolutionForVisualStudio(Process visualStudioProcess) {
				var vsi = getVSInstance(visualStudioProcess.Id);
				try { return vsi?.Solution.FullName;}
				catch (Exception) {} return null;
			}
			public static Process GetAttachedVisualStudio(Process ap) {
				var vsps = getVSProcess();
				foreach (Process vsp in vsps) {
					var vsi = getVSInstance(vsp.Id);
					if (vsi == null) continue;
					try {
						foreach (Process dp in vsi.Debugger.DebuggedProcesses)
							if (dp.Id == ap.Id) return dp;
					} catch (Exception) {}
				}
				return null;
			}
			public static void AttachVSToProcess(Process vsp, Process applicationProcess) {
				var vsi = getVSInstance(vsp.Id);
				if (vsi == null) return;
				//Find the process you want the VS instance to attach to...
				DTEProcess tp = vsi.Debugger.LocalProcesses.Cast<DTEProcess>().FirstOrDefault(process => process.ProcessID == applicationProcess.Id);
				//Attach to the process.
				if (tp != null) {
					tp.Attach();
					ShowWindow((int)vsp.MainWindowHandle, 3);
					SetForegroundWindow(vsp.MainWindowHandle);
				} else {
					throw new InvalidOperationException("Visual Studio process cannot find specified application '" + applicationProcess.Id + "'");
				}
			}
			public static Process GetVisualStudioForSolutions(List<string> sns) {
				foreach (string sn in sns) {
					var vsp = GetVSProc(sn);
					if (vsp != null) return vsp;
				}
				return null;
			}
			public static Process GetVSProc(string name) {
				var vsps = getVSProcess(); var e = false;
				foreach (Process vsp in vsps) {
					_DTE vsi = getVSInstance(vsp.Id);
					if (vsi == null) { e = true; continue; }
					try {
						string sn = Path.GetFileName(vsi.Solution.FullName);
						if (string.Compare(sn, name, StringComparison.InvariantCultureIgnoreCase)
							== 0) return vsp;
					} catch (Exception) { e = true; }
				}
				if (!e) log($@"No running Visual Studio process named ""{VSProcessName}"" were found.");
				return null;
			}
			#endregion
			#region Private Methods
			private static IEnumerable<Process> getVSProcess() {
				Process[] ps = Process.GetProcesses();
				//var vsp = ps.Where(p => p.Id == 11576);
				return ps.Where(o => o.ProcessName.Contains(VSProcessName));
			}
			private static _DTE getVSInstance(int processId) {
				IntPtr numFetched = IntPtr.Zero;
				IMoniker[] m = new IMoniker[1];
				GetRunningObjectTable(0, out var rot);
				rot.EnumRunning(out var ms); ms.Reset();
				var rons = new  List<string>();
				while (ms.Next(1, m, numFetched) == 0) {
					IBindCtx ctx;
					CreateBindCtx(0, out ctx);
					m[0].GetDisplayName(ctx, null, out var ron);
					rons.Add(ron);
					rot.GetObject(m[0], out var rov);
					if (rov is _DTE && ron.StartsWith(VSObjectName)) {
						int currentProcessId = int.Parse(ron.Split(':')[1]);
						if (currentProcessId == processId) {
							return (_DTE)rov;
						}
					}
				}
				log($@"No Visual Studio _DTE object was found with the name ""{VSObjectName}"" that resides in given process (PID:{processId}).");
				log("The processes exposes following objects:");
				foreach (var ron in rons) log(ron);
				return null;
			}
			#endregion
		}
		#endregion
	}
