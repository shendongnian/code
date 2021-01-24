    public static async Task<DirectoryResponse> SendRequestAsync(this LdapConnection conn, string target, string filter,
		SearchScope searchScope, params string[] attributeList)
	{
		if (conn == null)
		{
			throw new NullReferenceException();
		}
		var search_request = new SearchRequest(target, filter, searchScope, attributeList);
		var response = await Task<DirectoryResponse>.Factory.FromAsync(
			conn.BeginSendRequest,
			(iar) => conn.EndSendRequest(iar),
			search_request,
			PartialResultProcessing.NoPartialResultSupport,
			null);
		return response;
	}
