    Recipe recipeDto = MapInitializer.Mapper.Map<Recipe>(recipeElement);
    
    var facs = recipeDto.Facets;
    
    // Null out the facets that gets mapped from the xml. 
    recipeDto.Facets = new List<Facet>();
    
    // Reassign facet from the db. Otherwise, trying to save the recipe with the 
    // facets that was mapped from the xml will cause duplicate facts trying to insert.
    foreach (var f in facs)
    {
    	var dbFacet = ctx.Facet.Where(x => x.Taxonomy_id == f.Taxonomy_id && x.Name == f.Name).First();
    	recipeDto.Facets.Add(dbFacet);
    }
    
    ctx.Recipe.Add(recipeDto);
