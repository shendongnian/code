    public class SleepEntry
    {
    string Entry_number;
    string Entry_date;
    string Customer_number;
    string Entry_value;
    string Comment;
	[JsonProperty("Entry_number")]
    public string Entry_number1 { get => Entry_number; set => Entry_number = value; }
	[JsonProperty("Entry_date")]
    public string Entry_date1 { get => Entry_date; set => Entry_date = value; }
	 [JsonProperty("Custom_number1")]
    public string Customer_number1 { get => Customer_number; set => Customer_number = value; }
	[JsonProperty("Entry_value")]
    public string Entry_value1 { get => Entry_value; set => Entry_value = value; }
	[JsonProperty("Comment")]
    public string Comment1 { get => Comment; set => Comment = value; }
    }
    
