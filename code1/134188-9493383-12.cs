	public IQueryable<Part> SearchForParts(string[] query)
	{
		var q = db.Parts.AsQueryable(); 
		foreach (var qs in query)
		{
			string escaped_bs = qs.Replace("/", "//"),
				escaped_us = escaped_bs.Replace("_", "/_"),
				escaped_p = escaped_us.Replace("%", "/%"),
				escaped_br = escaped_p.Replace("[", "/["),
				likestr = string.Format("%{0}%", escaped_br);
			q = q.Where(x => SqlMethods.Like(x.partName, likestr, '/'));
		}
		return q;
	}
