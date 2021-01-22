        [Test]
        public void CanSaveTounamentAttachedToPlayer()
        {
            Player player = new Player();
            Tournament tournament = new Tournament();
            player.AddTournament(tournament);
            tournament.AddPlayer(player);
            Session.Save(player);
            Session.Flush();
        }
