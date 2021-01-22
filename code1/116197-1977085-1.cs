    public class Store
    {
        public virtual bool? AllowSavePasswords { get; set; }
        public virtual OptionSet GetEffectiveOptions(OptionSet globalOptions)
        {
            return new OptionSet
            {
                AllowSavePasswords = this.AllowSavePasswords ?? globalOptions.AllowSavePasswords,
                LoginTimeout = globalOptions.LoginTimeout
                // Repeat pattern for all options
            }
        }
    }
