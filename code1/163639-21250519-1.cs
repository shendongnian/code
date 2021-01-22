        public abstract class Operation
        {
            protected abstract Dictionary<string, int> getCodeTable();
            public int returnOpCode(string request){ return getCodeTable()[request]; }
        }
        public class ServerOperation : Operation
        {
            Dictionary<string, int> serverOpCodeTable = new Dictionary<string, int>()
            {
                {"LoginResponse", 0x00,},
                {"SelectionResponse", 0x01},
                {"BlahBlahResponse", 0x02}
            };
            protected override Dictionary<string, int> getCodeTable()
            {
                return serverOpCodeTable;
            }
        }
        public class ClientOperation : Operation
        {
            Dictionary<string, int> cilentOpCodeTable = new Dictionary<string, int>()
            {
                {"LoginResponse", 0x00,},
                {"SelectionResponse", 0x01},
                {"BlahBlahResponse", 0x02}
            };
            protected override Dictionary<string, int> getCodeTable()
            {
                return cilentOpCodeTable;
            }
        }
