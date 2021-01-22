public partial class WebReferenceName2 : System.Web.Services.Protocols.SoapHttpClientProtocol 
{
	// take the methodname and append Local to the end
	public Consolidated.ReturnType MethodName2Local(params)
	{
		// redirect the return value of the call to the consolidation method and return the new value
		return Consolidation.Convert(this.MethodName2(params);
	}
}
