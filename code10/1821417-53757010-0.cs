    using System;
	using System.Windows.Forms;
	using NDde.Server;
	using System.Timers;
	
	namespace DDEServer_Test
	{
		public partial class DDEServer_MainForm : Form
		{
			theDDEServer server;
			public DDEServer_MainForm()
			{
				InitializeComponent();
			}
			public void runDDEServer()
			{
				
				try
				{
					server = new theDDEServer("DDE_Server", this);
					server.Register();
				}
				catch (Exception ex)
				{
					MessageBox.Show("DDE Server registered failed.  " + ex.Message);
				}
			}
			private void DDEServer_MainForm_FormClosing(object sender, FormClosingEventArgs e)
			{
				if (server.IsRegistered)
					server.Unregister();
				server.Dispose();
			}
			private void button1_Click(object sender, EventArgs e)
			{
				runDDEServer();
			}
		}
		public sealed class theDDEServer : DdeServer
		{
			DDEServer_MainForm server_mainForm;
			private System.Timers.Timer _Timer = new System.Timers.Timer();
	
			public theDDEServer(string service, DDEServer_MainForm mainform) : base(service)
			{
				server_mainForm = mainform;
				_Timer.Elapsed += this.OnTimerElapsed;
				_Timer.Interval = 1000;
				_Timer.SynchronizingObject = this.Context;
			}
			private void OnTimerElapsed(object sender, ElapsedEventArgs args)
			{
				Console.WriteLine("Advise all");
				this.Advise("*", "*");
			}
	
			public override void Register()
			{
				Console.WriteLine("Register");
				base.Register();
				_Timer.Start();
			}
			public override void Unregister()
			{
				Console.WriteLine("Unregister");
				server_mainForm = null;
				_Timer.Stop();
				base.Unregister();
			}
			protected override bool OnBeforeConnect(string topic)
			{
				Console.WriteLine("OnBeforeConnect");
				return true;
			}
			protected override void OnAfterConnect(DdeConversation conversation)
			{
				Console.WriteLine("OnAfterConnect");
			}
			protected override void OnDisconnect(DdeConversation conversation)
			{
				Console.WriteLine("OnDisconnect");
			}
			protected override bool OnStartAdvise(DdeConversation conversation, string item, int format)
			{
				Console.WriteLine("OnStartAdvise");
				return format == 1;
			}
			protected override void OnStopAdvise(DdeConversation conversation, string item)
			{
				Console.WriteLine("OnStopAdvise");
			}
			protected override ExecuteResult OnExecute(DdeConversation conversation, string command)
			{
				Console.WriteLine("OnExecute");
				return ExecuteResult.Processed;
			}
			protected override PokeResult OnPoke(DdeConversation conversation, string item, byte[] data, int format)
			{
				Console.WriteLine("OnPoke");
				return PokeResult.Processed;
			}
			protected override RequestResult OnRequest(DdeConversation conversation, string item, int format)
			{
				Console.WriteLine("OnRequest");
				if (format == 1)
				{
					Console.WriteLine("Request item = " + item);
					return new RequestResult(System.Text.Encoding.ASCII.GetBytes("Now = " + DateTime.Now.ToString() + "\0"));
				}
				return RequestResult.NotProcessed;
			}
			protected override byte[] OnAdvise(string topic, string item, int format)
			{
				Console.WriteLine("OnAdvise");
				if (format == 1)
				{
					Console.WriteLine("Advise item = " + item);
					return System.Text.Encoding.ASCII.GetBytes("Now = " + DateTime.Now.ToString() + "\0");
				}
				return null;
			}
		}
	}
