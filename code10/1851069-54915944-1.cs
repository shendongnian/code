    public class CustomConverter : ITypeConverter<SourceInformation, IEnumerable<Destination>> {
        public IEnumerable<Destination> Convert(SourceInformation source, IEnumerable<Destination> destination, ResolutionContext context) {
            var destinations = new List<Destination>();
            foreach (var person in source.People) {
                var destination = context.Mapper.Map<Destination>(source);
                destination.Name = NameUtilStatic.FormatName(person.Name);
                destinations.Add(destination);
            }
            return destinations;
        }
    }
