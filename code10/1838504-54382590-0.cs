csharp
public class PropertyIgnoringContractResolver : DefaultContractResolver
    {
        private readonly Dictionary<Type, string[]> _ignoredPropertiesContainer = new Dictionary<Type, string[]>
        {
            // for type student, we would like to ignore Id and SchooldId properties.
            { typeof(Student), new string[] { "Id", "SchoolId" } }
        };
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            string[] ignoredPropertiesOfType;
            if (this._ignoredPropertiesContainer.TryGetValue(member.DeclaringType, out ignoredPropertiesOfType))
            {
                if (ignoredPropertiesOfType.Contains(member.Name))
                {
                    property.ShouldSerialize = instance => false;
                    // Also you could add ShouldDeserialize here as well if you want.
                    return property;
                }
            }
            return property;
        }
    }
then you should configure this in your `Startup.cs` in `ConfigureServices` like below
csharp
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new PropertyIgnoringContractResolver());
        }
However what i actually would do is that i would create response DTO's to match the needs of my API responses. Instead of returning raw entity types. Like;
csharp
[HttpGet]
public async Task<ActionResult<IEnumerable<Distributor>>> GetDistributor()
{
   return await _context.Distributor.Select(dist => new DistributorDTO 
   {
     Name = dist.Name,
     // so on..
   }).ToListAsync();
}
By implementing something like this, you would also optimize your database queries as well by only selecting the properties that the API response requires.
  [1]: https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Serialization_DefaultContractResolver.htm
