    private void InitialiseCOM()
		{
			System.Runtime.InteropServices.RegistrationServices services = new System.Runtime.InteropServices.RegistrationServices();
			try
			{
				System.Reflection.Assembly ass = Assembly.GetExecutingAssembly();
				services.RegisterAssembly(ass, System.Runtime.InteropServices.AssemblyRegistrationFlags.SetCodeBase);
				Type t = typeof(MyCOMClass);
				try
				{
					Registry.ClassesRoot.DeleteSubKeyTree("CLSID\\{" + t.GUID.ToString() + "}\\InprocServer32");
				}
				catch(Exception E)
				{
					Log.WriteLine(E.Message);
				}
				System.Guid GUID = t.GUID;
				services.RegisterTypeForComClients(t, ref GUID );
			}
			catch ( Exception e )
			{
				throw new Exception( "Failed to initialise COM Server", e );
			}
		}
