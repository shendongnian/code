    <#@ include file="StringEnum.ttinclude" #>
     
     
    <#+
    public static class Configuration
    {
        public static readonly string Namespace = "YourName.Space";
        public static readonly string EnumName = "ResponseStatusCode";
        public static readonly bool IncludeComments = true;
     
        public static readonly object Nodes = new
        {
            SUCCESS = "The response was successful.",
            NON_SUCCESS = "The request was not successful.",
            RESOURCE_IS_DISCONTINUED = "The resource requested has been discontinued and can no longer be accessed."
        };
    }
    #>
