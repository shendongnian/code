    using System;
    namespace Whatever
    {
        public static class Howdy
        {
    <# 
    	string[] webServices = new string[] {"wsContact", "wsDiary"};
    	foreach (string wsName in webServices)
    	{
    #>
    	public static <#=wsName#>.SoCredentialsHeader AttachContactCredentialHeader()
    	{
    		<#=wsName#>.SoCredentialsHeader ch = new <#=wsName#>.SoCredentialsHeader();
    		ch.AuthenticationType = <#=wsName#>.SoAuthenticationType.CRM5;
    		ch.UserId = "myUsername";
    		ch.Secret = apUtilities.CalculateCredentialsSecret(<#=wsName#>.SoAuthenticationType.CRM5,
                    apUtilities.GetDays(), "myUsername", "myPassword");
    		return ch;
    	}
        }    	
    <# } #>
    }
