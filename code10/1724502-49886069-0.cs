    private StringContent _httpContent
	private CustomHttpResponse _customHttpResponse
	
	public async Task<IHttpActionResult> PostOrganizationAsync(Organization organization)
	{
		using (var context = new ContextHandler())
		{
			bool added = await context.AddOrganizationAsync(organization);
			if (added)
			{
				return Ok();
			}
			else
			{
				this._httpContent = new StringContent("An organization with this Id already exists on the database"))
				this._customHttpResponse = new CustomHttpResponse(HttpStatusCode.Conflict, httpContent);
				return this._customHttpResponse;
			}
		}
	}
	
	protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
		    if (this._httpContent != null)
		    {
			    this._httpContent.Dispose();
		    }
		    if (this._customHttpResponse != null)
		    {
			    this._customHttpResponse.Dispose();
		    }
        }
	}
