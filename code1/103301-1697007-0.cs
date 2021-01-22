class Role {
int? Identity { get; }   // database identifier that I never really look at
string RoleEnum { get; } // the "enumeration" that is 
                         //   the well-known string, used in IsInRole()
string RoleName { get; } // a human-friendly, perhaps 
                         //   localizable name of the role
}
