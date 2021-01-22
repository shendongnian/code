var user = new DirectoryEntry($"LDAP://<SID={WindowsIdentity.GetCurrent().User.Value}>");
//Ask for only the attributes you want to read.
//If you omit this, it will end up getting every attribute with a value,
//which is unnecessary.
user.RefreshCache(new [] { "givenName", "sn" });
var firstName = user.Properties["givenName"].Value;
var lastName = user.Properties["sn"].Value;
If you're using ASP.NET and Windows Authentication, then you pull the SID from `HttpContext.User.Identity.User.Value`.
