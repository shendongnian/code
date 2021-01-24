    using System.Security.Principal;
    public class stuff
    {
       [SqlProcedure]
       public static void PutFiles()
       {
          using (WindowsImpersonationContext __ImpersonationIdentity =
                       SqlContext.WindowsIdentity.Impersonate())
          {
             ... {do stuff} ...
             __ImpersonationIdentity.Undo();
          }
       }
    }
