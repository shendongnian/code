using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
class QuoteResult
{
	public int Id { get; set; }
	public int? TimeZone { get; set; }
	public string Note { get; set; }
}
abstract class QuoteHelper<TQuote> where TQuote : Quote
{
	protected abstract Expression<Func<TQuote, int?>> GetTimeZone { get; }
	public IEnumerable<QuoteResult> GetQuoteResults(
		EfExpressionPropertyDbContext ctx)
	{
		IQueryable<TQuote> query = GetQuotes(ctx);
		var getTimeZone = GetTimeZone;
		var list = query
			.AsExpandable()
			.Select(v => new QuoteResult
			{
				Id = v.Id,
				TimeZone = getTimeZone.Invoke(v),
				Note = v.Note
				// and about 10 more simple properties like v.Id above
			})
			.ToList();
		return list;
	}
	public IQueryable<TQuote> GetQuotes(
		EfExpressionPropertyDbContext ctx)
	{
		return ctx.Set<TQuote>();
	}
}
class CommonQuoteHelper : QuoteHelper<CommonQuote>
{
	protected override Expression<Func<CommonQuote, int?>> GetTimeZone
	{
		get { return q => q.Area != null ? (int?)q.Area.TimeZone : null; }
	}
}
class PeculiarQuoteHelper : QuoteHelper<PeculiarQuote>
{
	protected override Expression<Func<PeculiarQuote, int?>> GetTimeZone
	{
		get { return q => q.Region != null ? (int?)q.Region.RegionalTimeZone : null; }
	}
}
