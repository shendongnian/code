    using System;
    using Ivi.Scope.Interop;
    using Tektronix.Tkdpo2k3k4k.Interop;
    using System.Diagnostics;
    using System.Threading;
    
    namespace Test_App
    {
    	public class DPO4034
    	{
    		#region [NOTES] Installing TekVisa Drivers for DPO4034
    		/*
    		1. Download and install the TekVisa Connectivity Software from here:
    		   https://www.tek.com/oscilloscope/tds7054-software/tekvisa-connectivity-software-v411
    
    		2. Check under Start -> All Programs -> TekVisa and see if the "Open Choice Installation Manager" shortcut works.If not, then update all shortcuts to point to the correct base folder for the TekVISA files, which is "C:\Program Files\IVI Foundation\VISA\".
    
    		3. Download the DPO4000 series IVI driver from here:
    		   https://www.tek.com/oscilloscope/dpo4054-software/dpo2000-dpo3000-dpo4000-ivi-driver
    
    		4. After running the unzip utility, open the unzipped folder and goto x64 -> Shared Components, and run the IviCleanupUtility_2.0.0.exe utility to make sure no shared IVI components exist.
    
    		5. Run the IviSharedComponents64_2.1.1.exe file to install shared components.
    
    		6. Go up one folder and open the IVI Driver Folder and run the Tkdpo2k3k4k-x64.msi installer to install the scope IVI driver.
    
    		7. In the VS project, add references to the following COM components:
    			• IviDriverLib
    			• IviScopeLib
    			• Tkdpo2k3k4kLib
    		
    		8. Right Click on each of the three references in the Solution Explorer and select Properties in the menu. When the properties window appears, set the "Embed Interop Types" property to False.
    		*/
    		#endregion
    
    		#region Class Variables
    
    		Tkdpo2k3k4kClass driver;	// IVI Driver representing the DPO4034
    		IIviScope scope;            // IVI Scope object representing the DPO4034
    		Thread t;                   // Thread to initialize the scope objects in to ensure that they async method calls do not run on the main thread
    
    		#endregion
    
    		#region Class Constructors
    
    		public DPO4034()
    		{
    			t = new Thread(new ThreadStart(Initialize));
    			t.Start();
    
    			// Wait for scope object to be initialized in the thread
    			while (this.scope == null);
    		}
    
    		~DPO4034()
    		{
    			this.Disconnect();
    			t.Abort();
    		}
    
    		#endregion
    
    		#region Public Properties
    
    		/// <summary>
    		/// Returns true if the scope is connected (initialized)
    		/// </summary>
    		public bool Connected
    		{
    			get
    			{
    				return this.driver.IIviDriver_Initialized;
    			}
    		}
    
    		#endregion
    
    		#region Public Methods
    
    		/// <summary>
    		/// Initializes the connection to the scope
    		/// <paramref name="reset"/>Resets the scope after connecting if set to true</param>
    		/// </summary>
    		/// <returns>True if the function succeeds</returns>
    		public bool Connect(bool reset = false)
    		{
    			try
    			{
    				if (!this.Connected)
    				{
    					this.Disconnect();
    				}
    
    				this.driver.Initialize("TCPIP::10.10.0.200::INSTR", true, reset, "Simulate=false, DriverSetup= Model=DPO4034");
    				return true;
    			}
    			catch (Exception ex)
    			{
    				PrintError(ex, "Connect");
    				return false;
    			}
    		}
    		
    		/// <summary>
    		/// Closes the connection to the scope
    		/// </summary>
    		/// <returns>True if the function succeeds</returns>
    		public bool Disconnect()
    		{
    			try
    			{
    				if (this.Connected)
    				{ 
    					this.driver.Close();
    				}
    				return true;
    			}
    			catch (Exception ex)
    			{
    				PrintError(ex, "Disconnect");
    				return false;
    			}
    		}
    
    		/// <summary>
    		/// Reads the average value of the waveform on the selected channel
    		/// </summary>
    		/// <param name="channel">1-4 for channels 1 to 4</param>
    		/// <returns>The measured average value</returns>
    		public double ReadWaveformAverage(int channel)
    		{
    			if (this.Connected)
    			{
    				try
    				{
    					double value = 0;
    					this.scope.Measurements.Item["CH" + channel.ToString()].FetchWaveformMeasurement(IviScopeMeasurementEnum.IviScopeMeasurementVoltageAverage, ref value);
    					return value;
    				}
    				catch (Exception ex)
    				{
    					PrintError(ex, "ReadWaveformAverage");
    					return 0;
    				}
    			}
    			else
    			{
    				PrintError("Oscilloscope not connected", "ReadWaveformAverage");
    				return 0;
    			}
    		}
    
    		#endregion
    
    		#region Private Methods
    
    		private void Initialize()
    		{
    			this.driver = new Tkdpo2k3k4kClass();
    			this.scope = (IIviScope)driver;
    
    			// Does nothing but allow the objects to exist on the separate thread
    			while (true)
    			{
    				Thread.Sleep(int.MaxValue);
    			}
    		}
    
    		/// <summary>
    		/// Prints an error message to the debug console
    		/// </summary>
    		/// <param name="err">Error object</param>
    		/// <param name="source">Source of the error</param>
    		private void PrintError(Exception err, string source = "") //, bool showMessageBox = false)
    		{
    			Debug.Print($"Error: {err.Message}");
    			Debug.Print($"Source: {source}");
    		}
    
    		/// <summary>
    		/// Prints an error message to the debug console
    		/// </summary>
    		/// <param name="err">Error object</param>
    		/// <param name="source">Source of the error</param>
    		private void PrintError(string error, string source = "")
    		{
    			Debug.Print($"Error: {error}");
    			Debug.Print($"Source: {source}");
    		}
    
    		#endregion
    	}
    }
