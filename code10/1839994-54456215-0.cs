    public static class ListRepereExtensionMethods
    {
    	public static List<Repere> GroupByName(this List<Repere> liste_rep)
    	{
    		List<Repere> liste_rep_group = liste_rep.GroupBy(l => l.Name)
    			.Select(cl => new Repere
    			{
    				Quantite = cl.Sum(c => c.TotalQuantity),
    				TotalQuantity = cl.Sum(c => c.TotalQuantity),
    				ID = -1,
    				IdAff = cl.First().IdAff,
    				Name = cl.First().Name,
    				NameOri = cl.First().Name,
    				Nom_aff = cl.First().Nom_aff,
    				Profil = cl.First().Profil,
    				Longueur = cl.First().Longueur,
    				Hauteur = cl.First().Hauteur,
    				Largeur = cl.First().Largeur,
    				Poids = cl.First().Poids,
    				Priorite = cl.Min(c => c.Priorite),
    				Matiere = cl.First().Matiere,
    				Angle1 = cl.First().Angle1,
    				Angle2 = cl.First().Angle2,
    				AngleAile1 = cl.First().AngleAile1,
    				AngleAile2 = cl.First().AngleAile2,
    				GroupeProfil = cl.First().GroupeProfil,
    				ListOperations = (cl.SelectMany(g=>g.ListOperations).GroupBy(o=>o.ID)
    					.Select(go => new Operation
    						{
    							ID = go.First().ID,
    							QtyFinished = go.Sum(o => o.QtyFinished),
    							Color=go.First().Color,
    						})).ToList()
    				...
    			}).ToList();
    	}
    }
