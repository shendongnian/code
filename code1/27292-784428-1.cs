       [Test]
        public void CanSavePlayerAttachedToTournament()
        {
            Player player = new Player();
            Tournament tournament = new Tournament();
            player.AddTournament(tournament);
            tournament.AddPlayer(player);
            Session.Save(tournament);
            Session.Flush();
        }
