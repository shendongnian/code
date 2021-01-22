	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	bool canBeAdmin = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
	Console.WriteLine("GetCurrent IsInRole: canBeAdmin:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	canBeAdmin = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).Claims.Any((c) => c.Value == "S-1-5-32-544");
	Console.WriteLine("GetCurrent Claim: canBeAdmin?:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	canBeAdmin = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole("Administrator");
	Console.WriteLine("GetCurrent IsInRole \"Administrator\": canBeAdmin?:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	canBeAdmin = (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole("Admin");
	Console.WriteLine("GetCurrent IsInRole \"Admin\": canBeAdmin?:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	canBeAdmin = WindowsPrincipal.Current.IsInRole("Admin");
	Console.WriteLine("Current IsInRole \"Admin\": canBeAdmin:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	canBeAdmin = WindowsPrincipal.Current.IsInRole("Administrator");
	Console.WriteLine("Current IsInRole \"Administrator\": canBeAdmin:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	canBeAdmin = WindowsPrincipal.Current.Claims.Any((c) => c.Value == "S-1-5-32-544");
	Console.WriteLine("Current Claim: canBeAdmin?:{0}", canBeAdmin);
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	Console.WriteLine("WindowsPrincipal Claims:");
	Console.WriteLine("---------------------");
	var propertyCount = 0;
	foreach (var claim in WindowsPrincipal.Current.Claims)
	{
		Console.WriteLine("{0}", (propertyCount++).ToString());
		Console.WriteLine("{0}", claim.ToString());
		Console.WriteLine("Issuer:{0}", claim.Issuer);
		Console.WriteLine("Subject:{0}", claim.Subject);
		Console.WriteLine("Type:{0}", claim.Type);
		Console.WriteLine("Value:{0}", claim.Value);
		Console.WriteLine("ValueType:{0}", claim.ValueType);
	}
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	Console.WriteLine("WindowsPrincipal Identities Claims");
	Console.WriteLine("---------------------");
	propertyCount = 0;
	foreach (var identity in WindowsPrincipal.Current.Identities)
	{
		foreach (var claim in identity.Claims)
		{
			Console.WriteLine("{0}", (propertyCount++).ToString());
			Console.WriteLine("{0}", claim.ToString());
			Console.WriteLine("Issuer:{0}", claim.Issuer);
			Console.WriteLine("Subject:{0}", claim.Subject);
			Console.WriteLine("Type:{0}", claim.Type);
			Console.WriteLine("Value:{0}", claim.Value);
			Console.WriteLine("ValueType:{0}", claim.ValueType);
		}
	}
	Console.WriteLine("---------------------");
	Console.WriteLine("---------------------");
	Console.WriteLine("Principal Id Claims");
	Console.WriteLine("---------------------");
	var p = new WindowsPrincipal(WindowsIdentity.GetCurrent());
	foreach (var claim in (new WindowsPrincipal(WindowsIdentity.GetCurrent())).Claims)
	{
		Console.WriteLine("{0}", (propertyCount++).ToString());
		Console.WriteLine("{0}", claim.ToString());
		Console.WriteLine("Issuer:{0}", claim.Issuer);
		Console.WriteLine("Subject:{0}", claim.Subject);
		Console.WriteLine("Type:{0}", claim.Type);
		Console.WriteLine("Value:{0}", claim.Value);
		Console.WriteLine("ValueType:{0}", claim.ValueType);
	}
	Console.WriteLine("press the ENTER key to end");
	Console.ReadLine();
