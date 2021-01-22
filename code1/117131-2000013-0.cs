    var predicate = PredicateBuilder.False<WebPath>();
    foreach (string role in rolesForUser)
    {
      predicate = predicate.Or (p => p.roles.Any(r => r.Id == role.Id));
    }
    var authentications = _entities.WebPaths.AsExpandable()
             .Where(p => p.Path == path)
             .Where(predicate);
    return (authentications.Count() > 0);
