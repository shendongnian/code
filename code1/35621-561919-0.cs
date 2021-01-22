public partial class WebReferenceName1 : System.Web.Services.Protocols.SoapHttpClientProtocol 
{
	// take the methodname and append Local to the end
	public Consolidated.ReturnType MethodName1Local(params)
	{
		// redirect the return value of the call to the consolidation method and return the new value
		return Consolidation.Convert(this.MethodName1(params);
	}
}
