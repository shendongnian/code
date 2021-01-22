    public class User
    {
       private readonly EncryptionService _encryptionService =
                       new EncryptionService();
       public virtual int Id { get; set; }
       public virtual DateTime? DateOfBirth
       {
         get
         {
           return _encryptionService.DecryptObject<DateTime?>(DateOfBirthEncrypted);
         }
         set
         {
           DateOfBirthEncrypted= _encryptionService.EncryptString(value.Value
                                       .ToString("yyyy-MM-dd HH:mm:ss"));
         }
       }
       [Obsolete("Use the 'DateOfBirth' property -- this property is only to be used by NHibernate")]
       public virtual string DateOfBirthEncrypted { get; set; }
    }
    
    
    public sealed class UserMap : ClassMap<User>
    {
      public UserMap()
      {
        WithTable("dbo.[User]");
        Id(x => x.Id, "[ID]");
        Map(x => x.DateOfBirthEncrypted, "DOB");
      }
    }
