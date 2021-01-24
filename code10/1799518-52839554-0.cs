    public class Program
    {
        private static int _EventCount = 0;
        public static void Test_Import()
        {
            var str = @"10248|VINET|5|04071996|01081996|16071996|3|32.38" + Environment.NewLine
                        + "10249|TOMSP|6|05071996|16081996|10071996|1|11.61" + Environment.NewLine
                        + "ALFKI;Alfreds Futterkiste;Maria Anders;Sales Representative;Obere Str. 57;Berlin;Germany" + Environment.NewLine
                        + "ANATR;Ana Trujillo Emparedados y helados;Ana Trujillo;Owner;Avda. de la Constitución 2222;México D.F.;Mexico" + Environment.NewLine
                        + "10250 |HANAR|4|08071996|05081996|12071996|2|65.83" + Environment.NewLine
                        + "10111314012345";
            var engine = new MultiRecordEngine(typeof(Orders),
                typeof(Customer),
                typeof(SampleType));
            engine.RecordSelector = new RecordTypeSelector(CustomSelector);
            engine.AfterReadRecord += Engine_AfterReadRecord;
            var records = engine.ReadString(str);
            Assert.AreEqual(6, records.Count());
            Assert.AreEqual(6, _EventCount);
        }
        private static void Engine_AfterReadRecord(EngineBase engine, AfterReadEventArgs<object> e)
        {
            // Increment the event counter
            _EventCount++;
        }
        public static void Main(string[] args)
        {
            Test_Import();
            Console.WriteLine("OK");
            Console.ReadKey();
        }
    }
