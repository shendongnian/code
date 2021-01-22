    var roleIds = DetachedCriteria.For<User>
      .Add( Restrictions.IdEq( currentUser.Id ) )
      .CreateCriteria( "Roles" )
      .SetProjection( Projections.Id );
    
    var items = session.CreateCriteria<Item>()
      .CreateCriteria( "VisibleTo" )
      .Add( Subqueries.PropertyIn( "Id", roleIds) )
      .List<Item>();
