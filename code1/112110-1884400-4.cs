    namespace Wizardry
    {
        using System;
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
        public abstract class MultipleBaseMetadataAttribute : Attribute
        {
        }
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
        public abstract class SingletonBaseMetadataAttribute : Attribute
        {
        }
        public sealed class NameAttribute : SingletonBaseMetadataAttribute
        {
            public NameAttribute(string value) { this.Name = value; }
            public string Name { get; private set; }
        }
        public sealed class SpellsAttribute : MultipleBaseMetadataAttribute
        {
            public SpellsAttribute(params string[] value) { this.Spells = value; }
            public string[] Spells { get; private set; }
        }
    }
