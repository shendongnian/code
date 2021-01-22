    [DataContract]
    public class GetReportParameters
    {
     [DataMember(IsRequired=false)]
     public string parameters;
    
     [DataMember(IsRequired=false)]
     public int[] someIds;
    
     [DataMember(IsRequired=false)]
     bool includeAdditionalInformation
    }
