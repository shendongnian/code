    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using System.Diagnostics;
    namespace Ping
    {    
        public readonly int iSent = 0;
    	public readonly int iReceived = 0;
    	public readonly int iLost = 0; 
        public PingReceivedArgs (int iSent, int iReceived, int iLost)
    	{
        	this.iSent = iSent;
    		this.iReceived = iReceived;
    		this.iLost = iLost;
    	}
        public class PingFailedArgs : EventArgs
    	{
        	public readonly int iSent = 0;
    		public readonly int iReceived = 0;
    		public readonly int iLost = 0;
	    	public PingFailedArgs (int iSent, int iReceived, int iLost)
    		{
    			this.iSent = iSent;
    			this.iReceived = iReceived;
    			this.iLost = iLost;
    		}
    	}
   	/// <summary>
   	/// The Main Ping Class
   	/// </summary>
   	public class Ping
   	{
      		//Create delegate for events
                public delegate void PingReceivedHandler(object DataObj, PingReceivedArgs PingReceived);
      		public delegate void PingFailedHandler(object DataObj, PingFailedArgs PingFailed);
   		//The events we publish
   		public event PingReceivedHandler OnPingReceived;
   		public event PingFailedHandler OnPingFailed;
   		private void FirePingReceivedEvent( int iSent, int iReceived, int iLost)
   		{
   			PingReceivedArgs NewStatus = new PingReceivedArgs(iSent, iReceived, iLost);
   			if (OnPingReceived != null)
   			{
   				OnPingReceived(this,NewStatus);
   			}
   		}
   		private void FirePingFailedEvent(int iSent, int iReceived, int iLost)
   		{
   			PingFailedArgs NewStatus = new PingFailedArgs(iSent, iReceived, iLost);
   			if (OnPingFailed != null)
   			{
   				OnPingFailed(this,NewStatus);
   			}
   		}
   		private string _Host = "";
   		private bool _HostFound = false;
   		private int _PingSent = 0;
   		private int _PingReceived = 0;
   		private int _PingLost = 0;
   		private int _PauseBetweenPings = 2000;
   		private Thread _PingThread;
   		public string  Host
   		{
   			get { return _Host; }
   			set { _Host = value; }
   		}
   		public bool  HostFound
   		{
   			get { return _HostFound; }
   		}
   		public int PingSent
   		{
   			get { return _PingSent; }
   		}
   		public int PingReceived
   		{
   			get { return _PingReceived; }
   		}
   		public int PingLost
   		{
   			get { return _PingLost; }
   		}
   		
   		public int  PauseBetweenPings
   		{
   			get { return _PauseBetweenPings; }
   			set { _PauseBetweenPings = value; }
   		}
   		public Ping()
   		{
   			//
   			// TODO: Add constructor logic here
   			//
   		}
   		public void StartPinging()
   		{
   			try
   			{
   				if (_Host.Length == 0)
   				{
   					//LogStatus.WriteLog("Host name is blank,    stopping.","Error","StartPinging");
   					return;
   				}
                   if (_PingThread == null || (_PingThread.ThreadState &    (System.Threading.ThreadState.Unstarted | System.Threading.ThreadState.Background)) == 0)
   				{
   					_PingThread = new Thread(new ThreadStart(LoopAndPing));
   					_PingThread.IsBackground = true;
   					_PingThread.Start();
   				}
   			}
   			catch( Exception ex)	
   			{
   				//LogStatus.WriteErrorLog(ex,"Error","StartPinging");
   			}
   		}
   		public void StopPinging()
   		{
   			try
   			{
                   if (_PingThread != null && (_PingThread.ThreadState &    (System.Threading.ThreadState.Stopped | System.Threading.ThreadState.Aborted |    System.Threading.ThreadState.Unstarted | System.Threading.ThreadState.AbortRequested)) ==    0)
   				{
   					_PingThread.Abort();
   					_PingThread.Join();
   				}
   			}
   			catch (Exception ex)
   			{
   				//LogStatus.WriteErrorLog(ex, "Error", "StopPinging");
   			}
   		}
   		/// <summary>
   		/// LoopAndPing: Runs from a thread.  Basically loops and gathers stats.
   		/// </summary>
   		private void LoopAndPing()
   		{
   			bool bHostFound = false;
		
   			try
   			{
   				while(true)
   				{
   					_PingSent++;
   					bHostFound = PingHost(_Host);
   					if (bHostFound) 
   					{ 
   						_PingReceived++; 
   						_HostFound = true;
						   FirePingReceivedEvent(_PingSent,_PingReceived,_PingLost);
   					}
   					else  
   					{ 
   						_PingLost++; 
   						_HostFound = false;
						   FirePingFailedEvent(_PingSent,_PingReceived,_PingLost);
   					}
   					Thread.Sleep(_PauseBetweenPings);
   				}
   			}
   			catch(ThreadAbortException)
   			{
   				//No need to do anything!
   			}
   			catch(Exception e)	
   			{
   				//LogStatus.WriteErrorLog(e,"Error","LoopAndPing");
   			}
   		}
   		/// <summary>
   		/// PingHost - Send one ping to the host
   		/// </summary>
   		/// <param name="host">Can be an IP or Host name.</param>
   		/// <returns></returns>
   		public bool PingHost(string szHost)
   		{
   			bool bPingWorked = false;
   			try
   			{
   				string szCommand = "ping " + szHost + " -n 1";
   				Process p = new Process();
   				p.StartInfo.FileName = "cmd.exe";
   				p.StartInfo.Arguments = "/Q /A /C" + szCommand;
   				p.StartInfo.UseShellExecute = false;
   				p.StartInfo.RedirectStandardOutput = true;
   				p.StartInfo.RedirectStandardError = true;
   				p.StartInfo.CreateNoWindow = true;
   				p.Start();
   				string szCommandOutput = p.StandardOutput.ReadToEnd();
   				p.WaitForExit();
 
  				if (szCommandOutput.ToUpper().IndexOf("REPLY FROM") > -1)
   				{
   					bPingWorked = true;
   				}
   			}
   			catch(ThreadAbortException)
   			{
   				//No need to do anything!
   			}
   			catch(Exception e)	
   			{
   				//LogStatus.WriteErrorLog(e,"Error","PingHost");
   			}
   			return bPingWorked;
   		}
   	}
    }
