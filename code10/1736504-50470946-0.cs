    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyDBContext, Configuration>());
    var dbMigrator = new DbMigrator(new Configuration());
    var migrations = dbMigrator.GetPendingMigrations();
    if (migrations.Any())
    {
    	dbMigrator.Update();
    }
