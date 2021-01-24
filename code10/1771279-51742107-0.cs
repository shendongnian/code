    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    
    namespace EFTest
    {
       public class Program
       {
          static void Main( string[] args )
          {
             Database.SetInitializer( new DropCreateDatabaseAlways<EFTestContext>() );
    
             User userHans;
             User userFranz;
    
             var permissionA = "A";
             var permissionB = "B";
    
             using( var context = new EFTestContext() )
             {
                userHans = context.Users.Add( new User() { Name = "Hans" } );   // Id = 1
                userFranz = context.Users.Add( new User() { Name = "Franz" } ); // Id = 2
                context.SaveChanges();
             }
    
             SetPermission( userHans.Id, true, permissionA );
             SetPermission( userHans.Id, true, permissionB );
             SetPermission( userFranz.Id, true, permissionA );
             SetPermission( userFranz.Id, true, permissionB );
             ListAllPermissions();
             // 1: A
             // 1: B
             // 2: A
             // 2: B
    
             SetPermission( userFranz.Id, false, permissionA );    
             ListAllPermissions();
             // 1: A
             // 1: B
             // 2: B
    
             SetPermission( userHans.Id, false, permissionB );    
             ListAllPermissions();
             // 1: A
             // 2: B    
          }
    
          enum PermissionStatus
          {
             Granted,
             Revoked,
          }
    
          private static void ListAllPermissions()
          {
             using( var context = new EFTestContext() )
             {
                foreach( var permission in context.Permissions )
                {
                   Console.WriteLine( $"{permission.UserId}: {permission.Name}" );
                }
             }
             Console.ReadLine();
          }
    
          private static IList<Permission> SetPermission( int userId, bool permissionIsGranted, string key )
          {
             var permissionStatus = permissionIsGranted ? PermissionStatus.Granted : PermissionStatus.Revoked;
    
             using( var entity = new EFTestContext() )
             {
                var user = entity.Users.Single( x => x.Id == userId );
                var existingPermission = user.Permissions.SingleOrDefault( x => x.Name == key );
    
                switch( permissionStatus )
                {
                   case PermissionStatus.Granted:
                      if( existingPermission == null )
                      {
                         user.Permissions.Add( new Permission { Name = key } );
                         entity.SaveChanges();
                      }
                      break;
    
                   case PermissionStatus.Revoked:
                      if( existingPermission != null )
                      {
                         entity.Permissions.Remove( existingPermission );
                         entity.SaveChanges();
                      }
                      break;
                }
    
                var permissions = entity.Permissions
                                        .Where( x => x.UserId == userId )
                                        .ToList();
    
                return permissions;
             }
          }
       }
    }
