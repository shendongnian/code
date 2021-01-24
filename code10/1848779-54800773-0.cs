[DataContract]
public class Response
{
    [DataMember(Name = "isSuccess")]
    public bool IsSuccess { get; set; }
    
    [DataMember(EmitDefaultValue = false, Name = "source")]
    public string Source { get; set; }
  
    [DataMember(EmitDefaultValue = false, Name = "number")]
    public string Number { get; set; }
    [DataMember(EmitDefaultValue = false, Name = "message")]
    public string Message { get; set; }
} 
Once you have your model populated make sure that based on your condition, unwanted properties are at their default values. In this case strings are null.
Additional advantage: Using data contract would also allow you to follow C# naming standards for your properties as well while keeping your JSON coming out as expected. illustrated in code above
