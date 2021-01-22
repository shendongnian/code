        private void Execute(Assembly asm)
        {
            Migrator mig = new Migrator(Provider, ConnectionString, asm, Trace, new TaskLogger(this));
            mig.DryRun = DryRun;
            if (ScriptChanges)
            {
                using (StreamWriter writer = new StreamWriter(ScriptFile))
                {
                    mig.Logger = new SqlScriptFileLogger(mig.Logger, writer);
                    RunMigration(mig);
                }
            }
            else
            {
                RunMigration(mig);
            }
        }
        private void RunMigration(Migrator mig)
        {
            if (mig.DryRun)
                mig.Logger.Log("********** Dry run! Not actually applying changes. **********");
            if (_to == -1)
                mig.MigrateToLastVersion();
            else
                mig.MigrateTo(_to);
        }
