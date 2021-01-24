    public interface IFileBackup
    {
        Task Backup(byte[] file);
    }
    public interface IBackUpMechanismA : IFileBackup
    {
    }
    public class BackUpMechanismA : IBackUpMechanismA
    {
        //...
    }
    public interface IBackUpMechanismB : IFileBackup
    {
    }
    public class BackUpMechanismB : IBackUpMechanismB
    {
        //...
    }
