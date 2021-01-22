    using System;
    using System.Collections.Generic;
    using System.Text;
    using SharpSvn;
    using System.Net;
    using SVNMonitor.Entities;
    using System.Collections.ObjectModel;
    using System.Windows.Forms;
    using SVNMonitor.View.Dialogs;
    using SVNMonitor.Helpers;
    
    namespace SVNMonitor.SVN
    {
    	internal class SharpSVNClient
    	{
    		#region Fields
    
    		private const string RecommendProperty = "svnmonitor:recommend";
    
    		#endregion Fields
    
    		#region Methods
    
    		private static SvnClient GetSvnClient()
    		{
    			SvnClient client = new SvnClient();
    
    			return client;
    		}
    
    		private static SvnClient GetSvnClient(Source source)
    		{
    			SvnClient client = GetSvnClient();
    
    			SetAuthentication(client, source);
    			
    			return client;
    		}
    
    		private static void SetAuthentication(SvnClient client, Source source)
    		{
    			if (source.Authenticate)
    			{
    				SetAuthentication(client, source.UserName, source.Password);
    			}
    			else
    			{
    				SharpSvn.UI.SvnUI.Bind(client, (IWin32Window)null);
    			}
    		}
