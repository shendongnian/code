    static bool IsOutlook64Bit() {
	    using (RegistryKey officeKey = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Office")) {
		    if (officeKey != null) {
                Regex versionExp = new Regex(@"^[1-9][0-9]*\.[0-9]+$");
                string maxVersion = officeKey.GetSubKeyNames()
				    .Where(x => versionExp.IsMatch(x))
     				.OrderByDescending(x => Decimal.Parse(x))
	    			.FirstOrDefault();
		    	if (!String.IsNullOrEmpty(maxVersion)) {
				    using (RegistryKey key = officeKey.OpenSubKey(maxVersion + @"\Outlook")) {
					    if (key != null) {
						    string bitness = Convert.ToString(key.GetValue("Bitness", null));
						    return bitness.Equals("x64", StringComparison.OrdinalIgnoreCase);
					    }
				    }
			    }
		    }
	    }
	    throw new InvalidOperationException("Outlook not found on this machine.");
    }
