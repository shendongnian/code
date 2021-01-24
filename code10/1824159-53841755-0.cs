	var results = tousLesArticlesFromDb
		.Where
		(
			a => a.GetPropertyValue<IEnumerable<IPublishedContent>>("ficheArticle_typeDeContenu")
				  .FirstOrDefault()?.Name == @EnumResources.TypeDeContenu_Actualites
		)
		.OrderBy(a => a.CreateDate)
		.Take(criteriaModel.NbrItemsParPage);
