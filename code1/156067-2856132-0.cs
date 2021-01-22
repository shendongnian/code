    public Route Get(int routeId, int userId)
    {
        var query repository.Get<Route>().Where(r => r.Id == routeId);
        query = applySecurityModel(query, userId);
        return query.FirstOrDefault();
    }
    
    private IQueryable<T> applySecurityModel<T>(IQueryable<T> query, int userId) where T : ISecurable
    {
        return query.Where(t => t.UserId == userId);
    }
    
    public interface ISecurable
    {
        int UserId { get; set; }
    }
    
    public class Route
    {
        int Id { get; set; }
        int UserId { get; set; }
    }
