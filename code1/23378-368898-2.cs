    public class KeyNotFoundException : RegistryException
    {
        public KeyNotFoundException(string message)
            : base(message) { }
    }
    public class RegistryException : Exception
    {
        public RegistryException(string message)
            : base(message) { }
    }
    ....
    if (registryKey == null)
    {
        throw new KeyNotFoundException("Could not load settings from HKLM\foo\bar\baz.");
    }
