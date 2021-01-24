    var sourceList = new SourceList<YourType>(); // use this instead of ObservableCollection
    
    sourceList.Connect()
         .AutoRefres(x => x.Quantite) // refresh when this property changes
         .ToCollection()
         .Select(col => 
                    col
                .GroupBy(l => l.Name)
                .Select(cl => new Assemblage
                {
                    Quantite = cl.Sum(c => c.Quantite),
                    ID = 0,
                    IdAffaire = cl.First().IdAffaire,
                    Name = cl.First().Name,
                    Priorite = 0,
                    Dessin = cl.First().Dessin,
                    Groupe = cl.First().Groupe,
                    Priorite = cl.Max(c=>c.Priorite),
                    ListeIdOperations = cl.First().ListeIdOperations,
                }).ToList()
                )
           .Subscribe(col => PublicPropertyWithChangeNotification = col);
