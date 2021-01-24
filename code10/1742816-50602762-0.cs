    public async Task<ActionResult> UpdateDatabase(UpdateDatabaseModel updateDatabaseModel)
    {
        DbMigrationsConfiguration configuration = new Configuration();
        var migrator = new DbMigrator(migrationsConfiguration);
        migrator.Update(updateDatabaseModel.SelectedMigration);
        return this.View("ManageApplication");
     }
