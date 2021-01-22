    public class Encrypted<T>
    {
        private IHasEncryptedProperties _parent;
        public Encrypted(IHasEncryptedProperties parent)
        {
            _parent = parent;
        }
        public T Value
        {
            get
            {
                var encryptor = GetEncryptor(_parent.GetKey());
                // encrypt and return the value
            }
        }
    }
