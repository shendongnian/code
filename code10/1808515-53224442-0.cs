    var application = await Table.Include(a => a.ApplicationDisciplines)
    .ThenInclude(x => x.Discipline)
    .Where(x => x.Name.Equals(appName, StringComparison.InvariantCultureIgnoreCase))
    .Select(x => new Application(){
       Id = x.Id,
       Name = x.Name,
       ApplicationDisciplines = x.ApplicationDisciplines.Select(y => 
       new ApplicationDiscipline() {
    	   ApplicationId = y.ApplicationId,
    	   Application = y.Application,
    	   DisciplineId = y.Discipline.Id,
    	   Discipline = new Discipline() {
    			Id = y.Discipline.Id
    			DisciplineTranslations = y.Discipline.DisciplineTranslations.Where(z => z.Language.Key == languageKey).ToList()
    	   }		
       })
    }).SingleOrDefaultAsync();
