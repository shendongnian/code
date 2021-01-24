	const string FILE_PATTERN = "*.xlsx";
	string excelFolder;
	string[] excelFiles;
	excelFolder = Dts.Variables["User::FolderPath"].Value.ToString();
	excelFiles = Directory.GetFiles(excelFolder, FILE_PATTERN,SearchOption.AllDirectories);
	Dts.Variables["User::ExcelFiles"].Value = excelFiles;
	//MessageBox.Show(excelFiles.ToString());
	Dts.TaskResult = (int)ScriptResults.Success;
