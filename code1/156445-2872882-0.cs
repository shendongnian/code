	PE_EXE3	pef;
	int		ok = FALSE;
	if (pef.openFile(fileNameAndPath))
	{
		if (pef.IsValid())
		{
			ok = pef.GetHasExecutableCode();
		}
		pef.closeFile();
	}
