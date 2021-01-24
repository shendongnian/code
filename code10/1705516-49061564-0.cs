        [Test]
        public void Frame1CommandShouldIncludeParts1and2and2()
        {
            var expected = new byte[] {0x1, 0x02, 0x3, 0x4, 0x3, 0x4};
            var actual = Frame.Frame1.Command;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Frame2CommandShouldIncludeParts1and3()
        {
            var expected = new byte[] {0x1, 0x02, 0x5, 0x6};
            var actual = Frame.Frame2.Command;
            Assert.AreEqual(expected, actual);
        }
        public class RequestModel
        {
            public byte[] Command { get; set; }
            public int ReceiveLength { get; set; }
        }
        public static class Frame
        {
            private static readonly byte[] CommandPart1 = { 0x1, 0x02 };
            private static readonly byte[] CommandPart2 = { 0x3, 0x4 };
            private static readonly byte[] CommandPart3 = { 0x5, 0x6 };
            public static RequestModel Frame1 = new RequestModel
            {
                Command = ConcatArrays(CommandPart1, CommandPart2, CommandPart2),
                ReceiveLength = 16
            };
            public static RequestModel Frame2 = new RequestModel
            {
                Command = ConcatArrays(CommandPart1, CommandPart3),
                ReceiveLength = 16
            };
            private static T[] ConcatArrays<T>(params T[][] list)
            {
                var result = new T[list.Sum(a => a.Length)];
                int offset = 0;
                for (int x = 0; x < list.Length; x++)
                {
                    list[x].CopyTo(result, offset);
                    offset += list[x].Length;
                }
                return result;
            }
        }
