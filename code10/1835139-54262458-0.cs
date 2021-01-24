using LinqKit;
    public IQueryable<Tuple<Document, Rating>> GetDocumentsWithRating(IQueryable<Document> documents, int id)
    {
        var getRatingExpression = _ratingsProvider.GetRating;
        return documents.AsExpandable().Select(x => new
        {
            Document = x,
            Rating = getRatingExpression.Invoke(x, id)
        }).AsEnumerable()
            .Select(x => new Tuple<Document, Rating>(x.Document, x.Rating)).AsQueryable().Where(x.Item2 == Rating.Ok);
    }
----------
Answer to your second question:
    public Expression<Func<Document, int, Rating>> GetRating
    {
        get
        {
            return (document, id) =>
                document.Calculations.Where(x => x.CId == id).Any() ?
                document.Calculations
                        .Where(x => x.CId == id)
                        .Select(x => x.Rating.HasValue ? x.Rating.Value : Rating.None)
                        .Single()
                Rating.Unknown;
        }
    }
Answer to the .AsEnumerable() part of your second question:
I guess the problem you had came from the use of Tuple&lt;Document, Rating\>, try to define a class 
public class DocumentRating
{
    public Document { get; set; }
    public Rating { get; set; }
}
    public IQueryable<DocumentRating> GetDocumentsWithRating(IQueryable<Document> documents, int id)
    {
        var getRatingExpression = _ratingsProvider.GetRating;
        return documents.AsExpandable().Select(x => new DocumentRating
        {
            Document = x,
            Rating = getRatingExpression.Invoke(x, id)
        })
        .Where(x.Item2 == Rating.Ok);
    }
