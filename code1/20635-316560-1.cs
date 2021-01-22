    using System;
    using System.ServiceModel;
    
    namespace Sportina.EnterpriseSystem.Client.Framework.Helpers
    {
    	public delegate void UseServiceDelegate<TServiceProxy>(TServiceProxy proxy);
    
    	public static class ServiceHelper<TServiceClient, TServiceInterface> where TServiceClient : ClientBase<TServiceInterface>, new() where TServiceInterface : class
    	{
    		public static void Use(UseServiceDelegate<TServiceClient> codeBlock)
    		{
    			TServiceClient proxy = null;
    			bool success = false;
    			try
    			{
    				proxy = new TServiceClient();				
    				codeBlock(proxy);
    				proxy.Close();
    				success = true;
    			}
    			catch (Exception ex)
    			{
    				Common.Logger.Log.Fatal("Service error: " + ex);                				
    			    throw;
    			}
    			finally
    			{
    				if (!success && proxy != null)
    					proxy.Abort();
    			}
    		}
    	}
    }
