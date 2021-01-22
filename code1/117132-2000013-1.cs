    var predicate = PredicateBuilder.False<WebPath>();
    foreach (var role in from roles in rolesForUser 
                         from r in roles.Role
                         select r)
    {
      predicate = predicate.Or (p => p.roles.Any(r => r.Id == role.Id));
    }
    var authentications = _entities.WebPaths.AsExpandable()
             .Where(p => p.Path == path)
             .Where(predicate);
    return (authentications.Count() > 0);
