    public abstract partial class Primitive
    {
        protected abstract object ValueObject { get; }
        public override bool Equals(object obj)
        {
            return obj is Primitive p ? this.ValueObject.Equals(p.ValueObject) : false;
        }
        ...
    }
    public sealed class Bool : Primitive
    {
        protected override object ValueObject => this.Value;
        public bool Value { get; set; }
        public override PrimitiveKind PrimitiveKind => PrimitiveKind.Bool;
    }
