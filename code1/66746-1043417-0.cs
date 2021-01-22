    class IdentifyClientsDueForReview {
       public void CanStartSearch() {
          var s = new ClientSearcher();
       }
       public void CanSearchClients() {
          var s = new ClientSearcher();
          var r = s.Find(c => c.Id == 1);
          Assert.IsNotNull(r);
       }
       public void Finds10Clients() {
          var db = new MockDB();
          // Clients that need review
          for (int i = 0; i < 10; i++) {
             db.Add(new Client() { 
                NextReview = DateTime.Today.SubtractDays(i) 
             });
          }
          // Clients that don't need review
          for (int i = 0; i < 10; i++) {
             db.Add(new Client() { 
                NextReview = DateTime.Today.AddDays(i) 
             });
          }
          var s = new ClientSearcher(db);
          var r  = s.Find(c => c.NextReview <= DateTime.Today);
          Assert.AreEqual(10, r.Count);
       }
    }
