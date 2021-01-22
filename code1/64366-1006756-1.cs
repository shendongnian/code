     public static void foo() {
         Microsoft.SqlServer.Management.Smo.Server server = new ServerConnection("<server name>");
         Microsoft.SqlServer.Management.Smo.Database db = server.Databases["<database name>"];
         Console.WriteLine(db.FileGroups[0].Files[0].FileName);
         Console.WriteLine(db.LogFiles[0].FileName);
      }
