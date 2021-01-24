	IQueryable<ExplotacionsAgraries> consulta = db.ExplotacionsAgraries;
	var result = null;
	foreach (string DataColumn in list) 
    {
		if (DataColumn=="Nom") 
        {
			if (result == null) 
			{
				result = consulta.Where(x => x.nom.Contains(valueSearch));
			}
			else 
			{
				result = result.Union(consulta.Where(x => x.nom.Contains(valueSearch)));
			}
		}
		if (DataColumn=="Representant") 
		{
			if (result == null) 
			{
				result = consulta.Where(x => x.representant.Contains(valueSearch));
			}
			else 
			{
				result = result.Union(consulta.Where(x => x.representant.Contains(valueSearch)));
			}
		}
	}
