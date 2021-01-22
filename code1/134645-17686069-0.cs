		/// <summary>
		/// Starts the GUI.
		/// </summary>
		public void StartGui()
		{
			Console.WriteLine("Starting GUI process...");
			try
			{
				var path = this.DetectInstalledCopy();
				var workingDir = path;
				var exePath = Path.Combine(path, "gui.exe");
				//// or ApplicationUnderTest.Launch() ???
				Console.Write("Starting new GUI process... ");
				this.guiProcess = Process.Start(new ProcessStartInfo
				{
					WorkingDirectory = workingDir,
					FileName = exePath,
					LoadUserProfile = true,
					UseShellExecute = false
				});
				Console.WriteLine("started GUI process (id:{0})", this.guiProcess.Id);
			}
			catch (Win32Exception e)
			{
				this.guiProcess = null;
				Assert.Fail("Unable to start GUI process; exception {0}", e);
			}
		}
		/// <summary>
		/// Detects the installed copy.
		/// </summary>
		/// <returns>The folder in which the MSI installed the GUI feature of the cortex 7 product.</returns>
		private string DetectInstalledCopy()
		{
			Console.WriteLine("Looking for install directory of CORTEX 7 GUI app");
			int buffLen = 1024;
			var buff = new StringBuilder(buffLen);
			var ret = NativeMethods.MsiGetComponentPath(
				"{XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX}",	// YOUR product GUID (see WiX installer)
				"{YYYYYYYY-YYYY-YYYY-YYYY-YYYYYYYYYYYY}",	// The GUI Installer component GUID
				buff,
				ref buffLen);
			if (ret == NativeMethods.InstallstateLocal)
			{
				var productInstallRoot = buff.ToString();
				Console.WriteLine("Found installation directory for GUI.exe feature at {0}", productInstallRoot);
				return productInstallRoot;
			}
			Assert.Fail("GUI product has not been installed on this PC, or not for this user if it was installed as a per-user product");
			return string.Empty;
		}
		/// <summary>
		/// Stops the GUI process. Initially by asking nicely, then chopping its head off if it takes too long to leave.
		/// </summary>
		public void StopGui()
		{
			if (this.guiProcess != null)
			{
				Console.Write("Closing GUI process (id:[{0}])... ", this.guiProcess.Id);
				if (!this.guiProcess.HasExited)
				{
					this.guiProcess.CloseMainWindow();
					if (!this.guiProcess.WaitForExit(30.SecondsAsMilliseconds()))
					{
						Assert.Fail("Killing GUI process, it failed to close within 30 seconds of being asked to close");
						this.guiProcess.Kill();
					}
					else
					{
						Console.WriteLine("GUI process closed gracefully");
					}
				}
				this.guiProcess.Close();	// dispose of resources, were done with the object.
				this.guiProcess = null;
			}
		}
