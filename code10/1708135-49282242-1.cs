               public IEnumerable<MåledataDTO> Get()
        {
            using (var e = new SCTHDBEntities())
            {
                Mapper.Initialize(config =>
                {
                    config.CreateMap<Måledata, MåledataDTO>();
                });
                var result = e.Måledata.ToList();
                return Mapper.Map<List<MåledataDTO>>(result);
