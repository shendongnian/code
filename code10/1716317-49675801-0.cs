	using System;
	using System.IO;
	using System.Xml;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	using System.Text;
	using Excel = Microsoft.Office.Interop.Excel;
	using Microsoft.SqlServer.Dts.Runtime;
	using System.Reflection;
	using VBIDE = Microsoft.Vbe.Interop;
	namespace ST_b2148758d9a44ee4bc0d01a2d900ce9d.csproj
	{
		[System.AddIn.AddIn("ScriptMain", Version = "1.0", Publisher = "", Description = "")] 
	 
		public partial class ScriptMain : Microsoft.SqlServer.Dts.Tasks.ScriptTask.VSTARTScriptObjectModelBase 
		{
			enum ScriptResults
			{
				Success = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Success,
				Failure = Microsoft.SqlServer.Dts.Runtime.DTSExecResult.Failure
			};
			public void Main()
			{
				Variables UserVariables = null;
				Dts.VariableDispenser.LockForRead("User::VBA_MacroName");
				Dts.VariableDispenser.LockForRead("User::VBA_Script");
				Dts.VariableDispenser.LockForRead("User::VBA_Parameters");
				Dts.VariableDispenser.GetVariables(ref UserVariables);
				//The macro and the macro name were stored in the original data set, so we can get those from local variables.
				string Macro = UserVariables["User::VBA_Script"].Value.ToString();
				string Macro_name = UserVariables["User::VBA_MacroName"].Value.ToString();
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(UserVariables["User::VBA_Parameters"].Value.ToString());
				XmlNodeList Parameters = doc.GetElementsByTagName (@"Parameter");
				object[] AllParamArray = new object[31];
				object[] MyParamArray = new object[Parameters.Count];
                //Fill the array with as many missing values as there are parameters in the Run macro command
				for (int i = 0; i < AllParamArray.Length; i++)
				{
					AllParamArray[i] = Missing.Value;
				}
                
                //get the parameters that we are actually going to use.
				for (int i = 0; i < Parameters.Count; i++)
				{
					MyParamArray[i] = Parameters[i].Attributes["Value"].Value.ToString();
				}
                //the first parameter is always the macro name
				AllParamArray[0] = Macro_name;
                //after that, we can insert our list of all the parameters we need into the list of all the parameters Excel needs
				MyParamArray.CopyTo(AllParamArray, 1);
				//Get Excel ready to be opened
				Excel.Application ExcelObject = default(Excel.Application);
				Excel.WorkbookClass oBook = default(Excel.WorkbookClass);
				Excel.Workbooks oBooks = default(Excel.Workbooks);
				//get the vba module ready
				VBIDE.VBComponent module = null;
				
				//open excel in the background
				ExcelObject = new Excel.Application();
				ExcelObject.Visible = false;
				ExcelObject.DisplayAlerts = false;
				
				//Open our report
				oBooks = ExcelObject.Workbooks;
				oBook = (Excel.WorkbookClass)oBooks.Add(Missing.Value);
							
				//Add a module to our report and populate it with our vba macro
				module = oBook.VBProject.VBComponents.Add(VBIDE.vbext_ComponentType.vbext_ct_StdModule);
				module.CodeModule.AddFromString(Macro);
				ExcelObject.Run
					(AllParamArray[0], AllParamArray[1], AllParamArray[2], AllParamArray[3], AllParamArray[4], AllParamArray[5], AllParamArray[6], AllParamArray[7], AllParamArray[8],
					 AllParamArray[9], AllParamArray[10], AllParamArray[11], AllParamArray[12], AllParamArray[13], AllParamArray[14], AllParamArray[15], AllParamArray[16], AllParamArray[17],
					 AllParamArray[18], AllParamArray[19], AllParamArray[20], AllParamArray[21], AllParamArray[22], AllParamArray[23], AllParamArray[24], AllParamArray[25], AllParamArray[26],
					 AllParamArray[27], AllParamArray[28], AllParamArray[29], AllParamArray[30]);
				UserVariables["User::TriedToSaveFileAs"].Value = UserVariables["User::Current_DataFile"].Value.ToString();
				oBook.Close(false,Missing.Value,Missing.Value);
				ExcelObject.Application.Quit();
				ExcelObject =null;
			}
		}
	}
