     using System;
     using SHDocVw;
     namespace WatiN.Core.Native.InternetExplorer
     {
	public class ProxyForIWebBrowser2InterfaceToWorkaroundHWNDBugs : IWebBrowser2
	{
		#region Implementation of IWebBrowser
		private readonly int _ExplicitHwndForIWebBrowser2;
		private readonly IWebBrowser2 _EmbeddedWebBrowserAsIWebBrowser2;
		public ProxyForIWebBrowser2InterfaceToWorkaroundHWNDBugs(IWebBrowser2 embeddedWebBrowserAsIWebBrowser2, IntPtr explicitHwnd)
		{
			_EmbeddedWebBrowserAsIWebBrowser2 = embeddedWebBrowserAsIWebBrowser2;
			_ExplicitHwndForIWebBrowser2 = (int)explicitHwnd;
		}
		void IWebBrowser.GoBack()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoBack();
		}
		void IWebBrowser2.GoForward()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoForward();
		}
		void IWebBrowser2.GoHome()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoHome();
		}
		void IWebBrowser2.GoSearch()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoSearch();
		}
		void IWebBrowser2.Navigate(string URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Navigate(URL, ref Flags, ref TargetFrameName, ref PostData, ref Headers);
		}
		void IWebBrowser2.Refresh()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Refresh();
		}
		void IWebBrowser2.Refresh2(ref object Level)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Refresh2(ref Level);
		}
		void IWebBrowser2.Stop()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Stop();
		}
		object IWebBrowser2.Application
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Application; }
		}
		object IWebBrowser2.Parent
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Parent; }
		}
		object IWebBrowser2.Container
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Container; }
		}
		object IWebBrowser2.Document
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Document; }
		}
		bool IWebBrowser2.TopLevelContainer
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.TopLevelContainer; }
		}
		string IWebBrowser2.Type
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Type; }
		}
		int IWebBrowser2.Left
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Left; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Left = value; }
		}
		int IWebBrowser2.Top
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Top; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Top = value; }
		}
		int IWebBrowser2.Width
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Width; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Width = value; }
		}
		int IWebBrowser2.Height
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Height; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Height = value; }
		}
		void IWebBrowser2.Quit()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Quit();
		}
		void IWebBrowser2.ClientToWindow(ref int pcx, ref int pcy)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.ClientToWindow(ref pcx, ref pcy);
		}
		void IWebBrowser2.PutProperty(string Property, object vtValue)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.PutProperty(Property, vtValue);
		}
		object IWebBrowser2.GetProperty(string Property)
		{
			return _EmbeddedWebBrowserAsIWebBrowser2.GetProperty(Property);
		}
		public void Navigate2(ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Navigate2(ref URL, ref Flags, ref TargetFrameName, ref PostData, ref Headers);
		}
		public OLECMDF QueryStatusWB(OLECMDID cmdID)
		{
			return _EmbeddedWebBrowserAsIWebBrowser2.QueryStatusWB(cmdID);
		}
		public void ExecWB(OLECMDID cmdID, OLECMDEXECOPT cmdexecopt, ref object pvaIn, ref object pvaOut)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.ExecWB(cmdID, cmdexecopt, ref pvaIn, ref pvaOut);
		}
		public void ShowBrowserBar(ref object pvaClsid, ref object pvarShow, ref object pvarSize)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.ShowBrowserBar(ref pvaClsid, ref pvarShow, ref pvarSize);
		}
		void IWebBrowser2.GoBack()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoBack();
		}
		void IWebBrowserApp.GoForward()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoForward();
		}
		void IWebBrowserApp.GoHome()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoHome();
		}
		void IWebBrowserApp.GoSearch()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoSearch();
		}
		void IWebBrowserApp.Navigate(string URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Navigate(URL, ref Flags, ref TargetFrameName, ref PostData, ref Headers);
		}
		void IWebBrowserApp.Refresh()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Refresh();
		}
		void IWebBrowserApp.Refresh2(ref object Level)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Refresh2(ref Level);
		}
		void IWebBrowserApp.Stop()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Stop();
		}
		object IWebBrowserApp.Application
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Application; }
		}
		object IWebBrowserApp.Parent
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Parent; }
		}
		object IWebBrowserApp.Container
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Container; }
		}
		object IWebBrowserApp.Document
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Document; }
		}
		bool IWebBrowserApp.TopLevelContainer
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.TopLevelContainer; }
		}
		string IWebBrowserApp.Type
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Type; }
		}
		int IWebBrowserApp.Left
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Left; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Left = value; }
		}
		int IWebBrowserApp.Top
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Top; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Top = value; }
		}
		int IWebBrowserApp.Width
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Width; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Width = value; }
		}
		int IWebBrowserApp.Height
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Height; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Height = value; }
		}
		void IWebBrowserApp.Quit()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Quit();
		}
		void IWebBrowserApp.ClientToWindow(ref int pcx, ref int pcy)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.ClientToWindow(ref pcx, ref pcy);
		}
		void IWebBrowserApp.PutProperty(string Property, object vtValue)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.PutProperty(Property, vtValue);
		}
		object IWebBrowserApp.GetProperty(string Property)
		{
			return _EmbeddedWebBrowserAsIWebBrowser2.GetProperty(Property);
		}
		void IWebBrowserApp.GoBack()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoBack();
		}
		void IWebBrowser.GoForward()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoForward();
		}
		void IWebBrowser.GoHome()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoHome();
		}
		void IWebBrowser.GoSearch()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.GoSearch();
		}
		void IWebBrowser.Navigate(string URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Navigate(URL, ref Flags, ref TargetFrameName, ref PostData, ref Headers);
		}
		void IWebBrowser.Refresh()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Refresh();
		}
		void IWebBrowser.Refresh2(ref object Level)
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Refresh2(ref Level);
		}
		void IWebBrowser.Stop()
		{
			_EmbeddedWebBrowserAsIWebBrowser2.Stop();
		}
		object IWebBrowser.Application
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Application; }
		}
		object IWebBrowser.Parent
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Parent; }
		}
		object IWebBrowser.Container
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Container; }
		}
		object IWebBrowser.Document
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Document; }
		}
		bool IWebBrowser.TopLevelContainer
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.TopLevelContainer; }
		}
		string IWebBrowser.Type
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Type; }
		}
		int IWebBrowser.Left
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Left; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Left = value; }
		}
		int IWebBrowser.Top
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Top; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Top = value; }
		}
		int IWebBrowser.Width
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Width; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Width = value; }
		}
		int IWebBrowser.Height
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Height; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Height = value; }
		}
		string IWebBrowser.LocationName
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.LocationName; }
		}
		string IWebBrowser2.LocationURL
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.LocationURL; }
		}
		bool IWebBrowser2.Busy
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Busy; }
		}
		string IWebBrowser2.Name
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Name; }
		}
		int IWebBrowser2.HWND
		{
			get { return _ExplicitHwndForIWebBrowser2; }
		}
		string IWebBrowser2.FullName
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.FullName; }
		}
		string IWebBrowser2.Path
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Path; }
		}
		bool IWebBrowser2.Visible
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Visible; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Visible = value; }
		}
		bool IWebBrowser2.StatusBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.StatusBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.StatusBar = value; }
		}
		string IWebBrowser2.StatusText
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.StatusText; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.StatusText = value; }
		}
		int IWebBrowser2.ToolBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.ToolBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.ToolBar = value; }
		}
		bool IWebBrowser2.MenuBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.MenuBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.MenuBar = value; }
		}
		bool IWebBrowser2.FullScreen
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.FullScreen; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.FullScreen = value; }
		}
		public tagREADYSTATE ReadyState
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.ReadyState; }
		}
		public bool Offline
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Offline; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Offline = value; }
		}
		public bool Silent
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Silent; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Silent = value; }
		}
		public bool RegisterAsBrowser
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.RegisterAsBrowser; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.RegisterAsBrowser = value; }
		}
		public bool RegisterAsDropTarget
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.RegisterAsDropTarget; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.RegisterAsDropTarget = value; }
		}
		public bool TheaterMode
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.TheaterMode; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.TheaterMode = value; }
		}
		public bool AddressBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.AddressBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.AddressBar = value; }
		}
		public bool Resizable
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Resizable; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Resizable = value; }
		}
		string IWebBrowser2.LocationName
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.LocationName; }
		}
		string IWebBrowserApp.LocationURL
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.LocationURL; }
		}
		bool IWebBrowserApp.Busy
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Busy; }
		}
		string IWebBrowserApp.Name
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Name; }
		}
		int IWebBrowserApp.HWND
		{
			get { return _ExplicitHwndForIWebBrowser2; }
		}
		string IWebBrowserApp.FullName
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.FullName; }
		}
		string IWebBrowserApp.Path
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Path; }
		}
		bool IWebBrowserApp.Visible
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Visible; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.Visible = value; }
		}
		bool IWebBrowserApp.StatusBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.StatusBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.StatusBar = value; }
		}
		string IWebBrowserApp.StatusText
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.StatusText; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.StatusText = value; }
		}
		int IWebBrowserApp.ToolBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.ToolBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.ToolBar = value; }
		}
		bool IWebBrowserApp.MenuBar
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.MenuBar; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.MenuBar = value; }
		}
		bool IWebBrowserApp.FullScreen
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.FullScreen; }
			set { _EmbeddedWebBrowserAsIWebBrowser2.FullScreen = value; }
		}
		string IWebBrowserApp.LocationName
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.LocationName; }
		}
		string IWebBrowser.LocationURL
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.LocationURL; }
		}
		bool IWebBrowser.Busy
		{
			get { return _EmbeddedWebBrowserAsIWebBrowser2.Busy; }
		}
		#endregion
           }
       }
