    [Test]
    public async Task MultipleSplitOn()
    {
        // Arrange
        using (var conn =new SqlConnection("Data Source=YourDb"))
        {
            await conn.OpenAsync();
            var sql = @"SELECT TOP 10 c.[Id] as CountryId
                        ,c.[Name]
                        ,s.[Id] as States_StateId
                        ,s.[Name] as States_Name
                        ,ct.[Id] as States_Cities_CityId
                        ,ct.[Name] as States_Cities_Name
                    FROM Country c 
                    JOIN State s ON s.[CountryId] = c.[Id]
		            JOIN City ct ON ct.[StateId] = s.[Id] ";
            // Act
            dynamic result = await conn.QueryAsync<dynamic>(sql);
                
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(Country), new [] { "CountryId" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(State), new [] { "StateId" });
            Slapper.AutoMapper.Configuration.AddIdentifiers(typeof(City), new [] { "CityId" });
            var countries = (Slapper.AutoMapper.MapDynamic<Country>(result) as IEnumerable<Country>).ToList();
            //Assert
            Assert.IsNotEmpty(countries);
            foreach (var country in countries)
            {
                Assert.IsNotEmpty(country.States);
                foreach (var state in country.States)
                {
                    Assert.IsNotEmpty(state.Cities);
                }
            }
        }
    }
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public List<State> States { get; set; }
    }
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
    }
