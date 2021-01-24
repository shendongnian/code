    public static class FlagsEnumExtensions
    {
        public static TEnum GetAggregate<TEnum>(this IEnumerable<TEnum> values) where TEnum : Enum
        {
            if (!typeof(TEnum).GetCustomAttributes<FlagsAttribute>().Any())
                throw new ArgumentException($"{typeof(TEnum)} does not have the Flags attribute");
            var flags = Enum.GetValues(typeof(TEnum)).Cast<object>().Select(Convert.ToInt64);
            var valuesAsLong = values.Select(v => Convert.ToInt64(v));
            var aggregated = flags.Where(flag => valuesAsLong.Any(value => (value & flag) == flag))
                .Aggregate<long, long>(0, (current, flag) => current | flag);
            return (TEnum)Enum.ToObject(typeof(TEnum), aggregated);
        }
    }
    [TestClass]
    public class EnumAggregateTests
    {
        [TestMethod]
        public void AggregatesByteEnum()
        {
            var values = new ByteEnum[] {ByteEnum.One, ByteEnum.Eight};
            var aggregate = values.GetAggregate();
            Assert.AreEqual(aggregate, ByteEnum.One | ByteEnum.Eight);
        }
        [TestMethod]
        public void AggregatesUint64Enum()
        {
            var values = new Uint64Enum[] { Uint64Enum.One,Uint64Enum.Eight};
            var aggregate = values.GetAggregate();
            Assert.AreEqual(aggregate, Uint64Enum.One | Uint64Enum.Eight);
        }
    }
    [Flags]
    public enum ByteEnum : Byte
    {
        One = 1,
        Two = 2,
        Four = 4,
        Eight = 8
    }
    [Flags]
    public enum Uint64Enum : UInt64
    {
        One = 1,
        Two = 2,
        Four = 4,
        Eight = 8
    }
