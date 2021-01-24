    public class TourDetail
    {
        [DynamoDBHashKey]
        public string TourId { get; set; }
        public List<TourItineraryDay> Itinerary { get; set; }
    }
