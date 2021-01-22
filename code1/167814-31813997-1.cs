    public enum Options {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five
    }
    public static class RandomEnum {
        private static Random _Random = new Random(Environment.TickCount);
        public static T Of<T>() {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Must use Enum type");
            Array enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(_Random.Next(enumValues.Length));
        }
    }
    
    [TestClass]
    public class RandomTests {
        [TestMethod]
        public void TestMethod1() {
            Options option;
            for (int i = 0; i < 10; ++i) {
                option = RandomEnum.Of<Options>();
                Console.WriteLine(option);
            }
        }
    }
