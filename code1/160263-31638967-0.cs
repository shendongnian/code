      public static class ContractExtensions {
        /// <summary>Throws <c>ContractException{name}</c> if <c>value</c> is null.</summary>
        /// <param name="value">Value to be tested.</param>
        /// <param name="name">Name of the parameter being tested, for use in the exception thrown.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "name")]
        [ContractAbbreviator] // Requires Assemble Mode = Standard Contract Requires
        public static void ContractedNotNull<T>([ValidatedNotNull]this T value, string name) where T : class {
          Contract.Requires(value != null,name);
        }
      }
    /// <summary>Decorator for an incoming parameter that is contractually enforced as NotNull.</summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class ValidatedNotNullAttribute : global::System.Attribute {}
