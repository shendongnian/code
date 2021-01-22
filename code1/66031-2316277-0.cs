    public class ShortGuid
    {
        private readonly Guid guid;
        private readonly string value;
        /// <summary>Create a 22-character case-sensitive short GUID.</summary>
        public ShortGuid(Guid guid)
        {
            if (guid == null)
            {
                throw new ArgumentNullException("guid");
            }
            this.guid = guid;
            this.value = Convert.ToBase64String(guid.ToByteArray())
                .Substring(0, 22)
                .Replace("/", "_")
                .Replace("+", "-");
        }
        /// <summary>Get the short GUID as a string.</summary>
        public override string ToString()
        {
            return this.value;
        }
        /// <summary>Get the Guid object from which the short GUID was created.</summary>
        public Guid ToGuid()
        {
            return this.guid;
        }
        /// <summary>Get a short GUID as a Guid object.</summary>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.FormatException"></exception>
        public static ShortGuid Parse(string shortGuid)
        {
            if (shortGuid == null)
            {
                throw new ArgumentNullException("shortGuid");
            }
            else if (shortGuid.Length != 22)
            {
                throw new FormatException("Input string was not in a correct format.");
            }
            return new ShortGuid(new Guid(Convert.FromBase64String
                (shortGuid.Replace("_", "/").Replace("-", "+") + "==")));
        }
        public static implicit operator String(ShortGuid guid)
        {
            return guid.ToString();
        }
        public static implicit operator Guid(ShortGuid shortGuid)
        {
            return shortGuid.guid;
        }
    }
