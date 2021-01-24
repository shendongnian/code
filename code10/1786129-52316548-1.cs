    builder.RegisterType<BackupMechanismA>().Named<IFileBackup>("BackUpMechanismA");
    builder.RegisterType<BackupMechanismB>().Named<IFileBackUp>("BackUpMechanismB");
    _backupA = container.ResolveNamed<IFileBackUp> 
    ("BackUpMechanismA"); 
    _backupB = container.ResolveNamed<IFileBackUp> 
    ("BackUpMechanismB");
  
