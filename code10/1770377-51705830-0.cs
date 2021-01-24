	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	namespace Rainbird.Tools.COMInterop
	{
		public class RunningObjectTable
		{
			private RunningObjectTable() { }
			[DllImport("ole32.dll")]
			private static extern int GetRunningObjectTable(uint reserved, out IRunningObjectTable pprot);
			[DllImport("ole32.dll")]
			private static extern int CreateBindCtx(uint reserved, out IBindCtx pctx);
			public static object GetRunningCOMObjectByName(string objectDisplayName)
			{
				IRunningObjectTable runningObjectTable = null;
				IEnumMoniker monikerList = null;
				try
				{
					if (GetRunningObjectTable(0, out runningObjectTable) != 0 || runningObjectTable == null) return null;
					runningObjectTable.EnumRunning(out monikerList);
					monikerList.Reset();
					IMoniker[] monikerContainer = new IMoniker[1];
					IntPtr pointerFetchedMonikers = IntPtr.Zero;
					while (monikerList.Next(1, monikerContainer, pointerFetchedMonikers) == 0)
					{
						IBindCtx bindInfo;
						string displayName;
						CreateBindCtx(0, out bindInfo);
						monikerContainer[0].GetDisplayName(bindInfo, null, out displayName);
						Marshal.ReleaseComObject(bindInfo);
						if (displayName.IndexOf(objectDisplayName) != -1)
						{
							object comInstance;
							runningObjectTable.GetObject(monikerContainer[0], out comInstance);
							return comInstance;
						}
					}
				}
				catch
				{
					return null;
				}
				finally
				{
					if (runningObjectTable != null) Marshal.ReleaseComObject(runningObjectTable);
					if (monikerList != null) Marshal.ReleaseComObject(monikerList);
				}
				return null;
			}
			public static IList<string> GetRunningCOMObjectNames()
			{
				IList<string> result = new List<string>();
				IRunningObjectTable runningObjectTable = null;
				IEnumMoniker monikerList = null;
				try
				{
					if (GetRunningObjectTable(0, out runningObjectTable) != 0 || runningObjectTable == null) return null;
					runningObjectTable.EnumRunning(out monikerList);
					monikerList.Reset();
					IMoniker[] monikerContainer = new IMoniker[1];
					IntPtr pointerFetchedMonikers = IntPtr.Zero;
					while (monikerList.Next(1, monikerContainer, pointerFetchedMonikers) == 0)
					{
						IBindCtx bindInfo;
						string displayName;
						CreateBindCtx(0, out bindInfo);
						monikerContainer[0].GetDisplayName(bindInfo, null, out displayName);
						Marshal.ReleaseComObject(bindInfo);
						result.Add(displayName);
					}
					return result;
				}
				catch
				{
					return null;
				}
				finally
				{
					if (runningObjectTable != null) Marshal.ReleaseComObject(runningObjectTable);
					if (monikerList != null) Marshal.ReleaseComObject(monikerList);
				}
			}
		}
	}
