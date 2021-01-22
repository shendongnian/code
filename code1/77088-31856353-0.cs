    using System.Security.Principal;
    // ...
        static bool IsElevated
        {
          get
          {
            return WindowsIdentity.GetCurrent().Owner
              .IsWellKnown(WellKnownSidType.BuiltinAdministratorsSid);
          }
        }
