    public interface IStopwatchType
    {
        TimeSpan TimeElapsed { get; }
        void StartTimeTest();
        void EndTimeTest();
    }
    public class StopwatchType : TailoredType, IStopwatchType
    {
        private Stopwatch stopwatch;
        private TimeSpan timeElapsed;
        public TimeSpan TimeElapsed
        {
            get
            {
                return timeElapsed;
            }
        }
        public StopwatchType()
        {
        }
        public void StartTimeTest()
        {
            ClearGarbage();
            stopwatch = Stopwatch.StartNew();
        }
        public void EndTimeTest()
        {
            stopwatch.Stop();
            timeElapsed = stopwatch.Elapsed;
        }
        private void ClearGarbage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();            
        }
    }
    public interface IDataStructureTimeTestHandler
    {
        void PerformTimeTestsForDataStructures();
    }
    public class DataStructureTimeTestHandler : IDataStructureTimeTestHandler
    {
        private IDataStructureTimeTest[] iDataStructureTimeTests;
        private TimeSpan[,] testsResults;
        public DataStructureTimeTestHandler()
        {
            iDataStructureTimeTests = new IDataStructureTimeTest[2];
            testsResults = new TimeSpan[4, 2];
        }
        public void PerformTimeTestsForDataStructures()
        {
            iDataStructureTimeTests[0] = new ArrayTimeTest();
            iDataStructureTimeTests[1] = new DictionaryTimeTest();
            for (int i = 0; i < iDataStructureTimeTests.Count(); i++)
            {
                testsResults[0, i] = iDataStructureTimeTests[0].InstantiationTime();
                testsResults[1, i] = iDataStructureTimeTests[0].WriteTime();
                testsResults[2, i] = iDataStructureTimeTests[0].ReadTime(LoopType.For);
                testsResults[3, i] = iDataStructureTimeTests[0].ReadTime(LoopType.Foreach);
            }
        }
    }
    public enum LoopType
    {
        For,
        Foreach
    }
    public interface IDataStructureTimeTest
    {
        TimeSpan InstantiationTime();
        TimeSpan WriteTime();
        TimeSpan ReadTime(LoopType loopType);
    }
    protected abstract class DataStructureTimeTest
    {
        protected IStopwatchType iStopwatchType;
        protected long numberOfElements;        
        protected int number;
        protected delegate void TimeTestDelegate();
        protected DataStructureTimeTest()
        {
            iStopwatchType = new StopwatchType();
            numberOfElements = 100000;
        }
        protected void TimeTestDelegateMethod(TimeTestDelegate timeTestMethod)
        {
            iStopwatchType.StartTimeTest();
            timeTestMethod();
            iStopwatchType.EndTimeTest();
        }
    }
    public class ArrayTimeTest : DataStructureTimeTest, IDataStructureTimeTest
    {
        private int[] integerArray;
        public TimeSpan InstantiationTime()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(InstantiationTime_));
            return iStopwatchType.TimeElapsed;
        }
        private void InstantiationTime_()
        {
            integerArray = new int[numberOfElements];
        }
        public TimeSpan WriteTime()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(WriteTime_));
            return iStopwatchType.TimeElapsed;
        }
        private void WriteTime_()
        {
            number = 0;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerArray[i] = number;
                number++;
            }
        }
        public TimeSpan ReadTime(LoopType dataStructureLoopType)
        {
            switch (dataStructureLoopType)
            {
                case LoopType.For:
                    ReadTimeFor();
                    break;
                case LoopType.Foreach:
                    ReadTimeForEach();
                    break;
            }
            return iStopwatchType.TimeElapsed;
        }
        private void ReadTimeFor()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(ReadTimeFor_));
        }
        private void ReadTimeFor_()
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                number = integerArray[i];
            }
        }
        private void ReadTimeForEach()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(ReadTimeForEach_));
        }
        private void ReadTimeForEach_()
        {
            foreach (int i in integerArray)
            {
                number = i;
            }
        }
    }
    public class DictionaryTimeTest : DataStructureTimeTest, IDataStructureTimeTest
    {
        private Dictionary<int, int> integerDictionary;
        public TimeSpan InstantiationTime()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(InstantiationTime_));
            return iStopwatchType.TimeElapsed;
        }
        private void InstantiationTime_()
        {
            integerDictionary = new Dictionary<int, int>();
        }
        public TimeSpan WriteTime()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(WriteTime_));
            return iStopwatchType.TimeElapsed;
        }
        private void WriteTime_()
        {
            number = 0;
            for (int i = 0; i < numberOfElements; i++)
            {
                integerDictionary.Add(number, number);
                number++;
            }
        }
        public TimeSpan ReadTime(LoopType dataStructureLoopType)
        {
            switch (dataStructureLoopType)
            {
                case LoopType.For:
                    ReadTimeFor();
                    break;
                case LoopType.Foreach:
                    ReadTimeForEach();
                    break;
            }
            return iStopwatchType.TimeElapsed;
        }
        private void ReadTimeFor()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(ReadTimeFor_));
        }
        private void ReadTimeFor_()
        {
            for (int i = 0; i < numberOfElements; i++)
            {
                number = integerDictionary[i];
            }
        }
        private void ReadTimeForEach()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(ReadTimeForEach_));
        }
        private void ReadTimeForEach_()
        {
            foreach (KeyValuePair<int, int> i in integerDictionary)
            {
                number = i.Value;
            }
        }
    }
