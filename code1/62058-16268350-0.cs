	using System;
	using Microsoft.Win32;
	namespace MyApp
	{
		class Program
		{
			static void Main(string[] args)
			{
				RegistryKey software = Registry.LocalMachine.OpenSubKey("Software");
				if (software != null)
				{
					RegistryKey adobe;
					// Try to get 64bit versions of adobe
					if (Environment.Is64BitOperatingSystem)
					{
						RegistryKey software64 = software.OpenSubKey("Wow6432Node");
						if (software64 != null)
							adobe = software64.OpenSubKey("Adobe");
					}
					// If a 64bit version is not installed, try to get a 32bit version
					if (adobe == null)
						adobe = software.OpenSubKey("Adobe");
					// If no 64bit or 32bit version can be found, chances are adobe reader is not installed.
					if (adobe != null)
					{
						RegistryKey acroRead = adobe.OpenSubKey("Acrobat Reader");
						if (acroRead != null)
						{
							string[] acroReadVersions = acroRead.GetSubKeyNames();
							Console.WriteLine("The following version(s) of Acrobat Reader are installed: ");
							foreach (string versionNumber in acroReadVersions)
							{
								Console.WriteLine(versionNumber);
							}
						}
						else
							Console.WriteLine("Adobe reader is not installed!");
					}
					else
						Console.WriteLine("Adobe reader is not installed!");
				}
			}
		}
	}
