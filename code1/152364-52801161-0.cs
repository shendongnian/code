	using System;
	using System.Diagnostics;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Forms;
	using AxMSTSCLib;
	namespace Utility.RemoteDesktop
	{
		public class Client
		{
			private int LogonErrorCode { get; set; }
			public void CreateRdpConnection(string server, string user, string domain, string password)
			{
				void ProcessTaskThread()
				{
					var form = new Form();
					form.Load += (sender, args) =>
					{
						var rdpConnection = new AxMSTSCLib.AxMsRdpClient9NotSafeForScripting();
						form.Controls.Add(rdpConnection);
						rdpConnection.Server = server;
						rdpConnection.Domain = domain;
						rdpConnection.UserName = user;
						rdpConnection.AdvancedSettings9.ClearTextPassword = password;
						rdpConnection.AdvancedSettings9.EnableCredSspSupport = true;
						if (true)
						{
							rdpConnection.OnDisconnected += RdpConnectionOnOnDisconnected;
							rdpConnection.OnLoginComplete += RdpConnectionOnOnLoginComplete;
							rdpConnection.OnLogonError += RdpConnectionOnOnLogonError;
						}
						rdpConnection.Connect();
						rdpConnection.Enabled = false;
						rdpConnection.Dock = DockStyle.Fill;
						Application.Run(form);
					};
					form.Show();
				}
				var rdpClientThread = new Thread(ProcessTaskThread) { IsBackground = true };
				rdpClientThread.SetApartmentState(ApartmentState.STA);
				rdpClientThread.Start();
				while (rdpClientThread.IsAlive)
				{
					Task.Delay(500).GetAwaiter().GetResult();
				}
			}
			private void RdpConnectionOnOnLogonError(object sender, IMsTscAxEvents_OnLogonErrorEvent e)
			{
				LogonErrorCode = e.lError;
			}
			private void RdpConnectionOnOnLoginComplete(object sender, EventArgs e)
			{
				if (LogonErrorCode == -2)
				{
					Debug.WriteLine($"    ## New Session Detected ##");
					Task.Delay(10000).GetAwaiter().GetResult();
				}
				var rdpSession = (AxMsRdpClient9NotSafeForScripting)sender;
				rdpSession.Disconnect();
			}
			private void RdpConnectionOnOnDisconnected(object sender, IMsTscAxEvents_OnDisconnectedEvent e)
			{
				Environment.Exit(0);
			}
		}
	}
