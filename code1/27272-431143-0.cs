     Mouvement mouvement = MockRepository.GenerateMock<Mouvement>();
     Tache tache = MockRepository.GenerateMock<Tache>();
     mouvement.Expect( m => m.Tache ).Return( tache );
     tache.Expect( t => t.Value ).Return( 100 );  // or whatever
     ... test code...
     tache.VerifyAllExpectations();
     mouvement.VerifyAllExpectations();
