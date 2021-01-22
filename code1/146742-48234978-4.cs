using System.CodeDom.Compiler;
namespace TheCompanyNamespace.Enumerations.Config
{
    [GeneratedCode("Auto Enum from DB Generator", "10")]
    public enum DatabasePushJobState
    {     
          Undefined = 0,
          Created = 1,        
    } 
    public partial class EnumDescription
    {
       public static string Description(DatabasePushJobState enumeration)
       {
          string description = "Unknown";
          switch (enumeration)
          {                   
              case DatabasePushJobState.Undefined:
                  description = "Undefined";
                  break;
                                         
              case DatabasePushJobState.Created:
                  description = "Created";
                  break;                 
           }
           return description;
       }
    }
    // select DatabasePushJobStateId, Name, coalesce(Description,Name) as Description
    //    from TheDefaultDatabase.[SchName].[DatabasePushJobState]
    //   where 1=1 order by DatabasePushJobStateId 
 }
