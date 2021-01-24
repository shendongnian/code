    private static Expression<Func<IArtist, bool>> CreateArtistFilterExpression(ArtistFilter filter)
    {
        Expression<Func<IArtist, bool>> expression = x => true;
        if(filter == null)
        {
            return expression;
        }
        if(!string.IsNullOrWhiteSpace(filter.SearchString))
        {
            expression = expression.And(x => x.Name.Contains(filter.SearchString));
        }
        if(filter.Type != null)
        {
            expression = expression.And(x => x is Type.Value);
        }
        if(filter.MinimumRating != null)
        {
            expression = expression.And(x => x.Rating >= filter.MinimumRating);
        }
        return expression;
    }
