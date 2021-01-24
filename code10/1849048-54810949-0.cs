public class RDStationService : IRDStationService
{
    public RDStationService(RDStationOptions server)
        {
            _endPoint = server.Url;
            _client = new RestClient
            {
                BaseUrl = new Uri(_endPoint)
            };
        }
    }
}
