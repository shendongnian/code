    public class EventLogRowMaps : IAutoMapperRegistrar
    {
        public void RegisterMaps()
        {
            Mapper.CreateMap<HistoryEntry, EventLogRow>()
                .ConstructUsing(he => new EventLogRow(he.Id))
                .ForMember(m => m.EventName, o => o.MapFrom(e => e.Description))
                .ForMember(m => m.UserName, o => o.MapFrom(e => e.ExecutedBy.Username))
                .ForMember(m => m.DateExecuted, o => o.MapFrom(e => string.Format("{0}", e.DateExecuted.ToShortDateString())));
        }
    }
