csharp
public App()
{
	try
	{
		var htCore = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HtCore.dll");
		if (File.Exists($"{htCore}_new"))
		{
			File.Copy(htCore, $"{htCore}_backup", true);
			File.Delete(htCore);
			File.Move($"{htCore}_new", htCore);
			File.Delete($"{htCore}_new");
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.Message);
	}
}
