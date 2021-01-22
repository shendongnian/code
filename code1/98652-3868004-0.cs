    [ServiceContract] 
    public interface IAirfareQuoteService
    {
        [OperationContract]
        [XmlSerializerFormat]
        float GetAirfare(Itinerary itinerary, DateTime date);
    }
   
    
