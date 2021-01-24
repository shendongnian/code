    public class Player
    {
        int Size { get; set; }
        int Player { get; set; }
    }
    // in the console
    var player = Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(data);
