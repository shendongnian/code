     public class   RemotePost{
         private  System.Collections.Specialized.NameValueCollection Inputs 
         = new  System.Collections.Specialized.NameValueCollection() ;
    
        public string  Url  =  "" ;
        public string  Method  =  "post" ;
        public string  FormName  =  "form1" ;
        
        public void  Add( string  name, string value ){
            Inputs.Add(name, value ) ;
         }
        
         public void  Post(){
            System.Web.HttpContext.Current.Response.Clear() ;
            
             System.Web.HttpContext.Current.Response.Write( "<html><head>" ) ;
            
             System.Web.HttpContext.Current.Response.Write( string .Format( "</head><body onload=\"document.{0}.submit()\">" ,FormName)) ;
            
             System.Web.HttpContext.Current.Response.Write( string .Format( "<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >" ,
            
            FormName,Method,Url)) ;
                for ( int  i = 0 ; i< Inputs.Keys.Count ; i++){
                System.Web.HttpContext.Current.Response.Write( string .Format( "<input name=\"{0}\" type=\"hidden\" value=\"{1}\">" ,Inputs.Keys[i],Inputs[Inputs.Keys[i]])) ;
             }
            System.Web.HttpContext.Current.Response.Write( "</form>" ) ;
             System.Web.HttpContext.Current.Response.Write( "</body></html>" ) ;
             System.Web.HttpContext.Current.Response.End() ;
         }
    } 
