    [DataContract]
    [KnownType(typeOf(LicenseMay2018))]
    [KnownType(typeOf(LicenseApril2018))]
    public abstract class License
    {
    
        [DataMember]
        public int ManagedObjectCount { get; set; }
    }
    
    [DataContract]
    public class LicenseMay2018 : License
    {
    
        public Frontend.DataTypes.License GetLicenseInfo(xml xml)
        {
            return new licenseMay2018();
        }
    
    }
    
    [DataContract]
    public class LicenseApril2018 : License
    {
    }
