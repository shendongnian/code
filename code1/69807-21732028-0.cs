        <%@
            WebHandler Language="C#"
            Class="Fimageview"
        %>
        
        /// <summary>
        /// Created By Rajib Chowdhury Mob. 01766-306306; Web: http://www.rajibs.tk
        /// Email: mysuccessstairs@hotmail.com
        /// FB: https://www.facebook.com/fencefunny
        /// 
        /// Complete This Page Coding On Fabruary 12, 2014
        /// Programing C# By Visual Studio 2013 For Web
        /// Dot Net Version 4.5
        /// Database Virsion MSSQL Server 2005
        /// </summary>
        
        using System;
        using System.IO;
        using System.Web;
    
    public class Fimageview : IHttpHandler {
    
        public void ProcessRequest(HttpContext context)
        {
    
            HttpResponse r = context.Response;
            r.ContentType = "image/png";
            string file = context.Request.QueryString["FImageName"];
            if (string.IsNullOrEmpty(file))
            {
                context.Response.Redirect("~/default");//If RequestQueryString Null Or Empty
            }
            try
            {
                if (file == "")
                {
                    context.Response.Redirect("~/Error/PageNotFound");
                }
                else
                {
                    r.WriteFile("/Catalog/Images/" + file); //Image Path If File Name Found
                }
            }
            catch (Exception)
            {
                context.Response.ContentType = "image/png";
                r.WriteFile("/yourImagePath/NoImage.png");//Image Path If File Name Not Found
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
