    public class AlbumMappingOverride : IAutoMappingOverride<Album>
    {
        public void Override(AutoMap<Album> mapping)
        {
            mapping.Map(x => x.Created).CustomSqlTypeIs("timestamp");
        }
    }
