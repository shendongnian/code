    using System;
    using System.Web;
    using System.Web.UI;
    using System.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using System.Data;
    
    namespace CustomHttpModule
    {
        public class HttpModuleImplementation : IHttpModule
        {
            #region IHttpModule Members
    
            public void Dispose()
            {
                
            }
    
            public void Init(HttpApplication context)
            {
                if (context == null)
                    throw new ArgumentNullException("Context == null");
    
                context.AuthorizeRequest += new EventHandler(this.ProcessRequestHandler);
            }
            #endregion
    
            private void DummpRequest(object sender, EventArgs e)
            {
            }
            //first check that user.identity record exist in database
            //If not then forward user to User registration page
            private void ProcessRequestHandler(object sender, EventArgs e)
            {
                try
                {
                    HttpApplication context = (HttpApplication)sender;
                    string strAbsoluteUri = context.Request.Url.AbsoluteUri.ToLower();
                                    //check if request is accessing aspx page
                    if (strAbsoluteUri.Substring(strAbsoluteUri.Length - 5, 5).Contains(".aspx"))
                    {
                        string userName = context.User.Identity.Name;
                        //replace Test Module with DB call to validate user data
                        if (!CheckUserInDb(userName))
                        {
                            if (!strAbsoluteUri.Contains("mypage.aspx"))
                                redirectToRegistrationPage(context);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            private void redirectToRegistrationPage(HttpApplication context)
            {
                context.Response.Redirect("http://" + context.Request.ServerVariables["HTTP_HOST"].ToString() + "Regpage.aspx", false);
            }
    
            private bool CheckUserInDb(string userName)
            {
                        return true;
            }
        }
    }
