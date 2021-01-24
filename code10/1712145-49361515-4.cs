     using (var context = new MedewerkerMeldingContext()){
     var medewerkers = context.medewerker;
     var medewerker_meldings = context.medewerker_melding;
            var testquery = from m in medewerkers
            join mm in medewerker_meldings on m.ID equals mm.medewerkerID
            where m.ID == id
            select new
            {
                m,
                mm
            };
            var getQueryResult = testquery.AsNoTracking().FirstOrDefault(); //AsNoTracking() will improve perfomance if you not need to track state
    }
