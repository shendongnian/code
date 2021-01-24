      protected override TroopMappingSession UpdateGameModel(TroopMappingSession g, TroopMappingSessionDto dto)
        {
            var retval = base.UpdateGameModel(g, dto);
            //if (dto.IsActiveBattle != null && dto.IsActiveBattle == false) {
                GameService.SaveToDatabase(g);
            //}
            return retval;
        }
