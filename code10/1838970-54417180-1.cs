    public class NHLStatsQuery : ObjectGraphType
    {
        public NHLStatsQuery(IPlayerRepository playerRepository, NHLStatsContext dbContext)
        {
            Field<ListGraphType<PlayerType>>(
                "players",
                resolve: context => {
                    return dbContext.Players.Select(p =>new Player { Id = p.Id, Name = p.Name });
                    //return playerRepository.All();
                });
        }
    }
