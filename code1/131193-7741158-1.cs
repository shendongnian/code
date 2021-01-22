    /// <summary>
    /// This class is only to fix building issue of NHibernate.ByteCode.Castle.dll 
    /// not being copied to bin directory of projects referencing data access 
    /// (either directly or indirectly)
    /// </summary>
    internal abstract class ReferenceHelper : ProxyFactory
    {
    }
