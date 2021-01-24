public class Role_AppUserMap : ClassMap<Role_AppUser>
{
   public Role_AppUserMap()
   {
       Table("Role_AppUser")
       CompositeId()
         .KeyProperty(x=>x.RoleId, "Id")
         .KeyProperty(x=>x.UserId, "UserId");
   }
}
