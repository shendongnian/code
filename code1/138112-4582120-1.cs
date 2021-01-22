    public interface IDataStructureTimeTestHandler
    {
        void PerformTimeTestsForDataStructures();
    }
    public class DataStructureTimeTestHandler : IDataStructureTimeTestHandler
    {
        // Example of use:
        //IDataStructureTimeTestHandler iDataStructureTimeTestHandler = new DataStructureTimeTestHandler();
        //iDataStructureTimeTestHandler.PerformTimeTestsForDataStructures();
        private IDataStructureTimeTest[] iDataStructureTimeTests;
        private TimeSpan[,] testsResults;
        public DataStructureTimeTestHandler()
        {
            iDataStructureTimeTests = new IDataStructureTimeTest[3];
            testsResults = new TimeSpan[4, 3];
        }
        public void PerformTimeTestsForDataStructures()
        {
            iDataStructureTimeTests[0] = new ArrayTimeTest();
            iDataStructureTimeTests[1] = new DictionaryTimeTest();
            iDataStructureTimeTests[2] = new ListTimeTest();
            for (int i = 0; i < iDataStructureTimeTests.Count(); i++)
            {
                testsResults[0, i] = iDataStructureTimeTests[i].InstantiationTime();
                testsResults[1, i] = iDataStructureTimeTests[i].WriteTime();
                testsResults[2, i] = iDataStructureTimeTests[i].ReadTime(LoopType.For);
                testsResults[3, i] = iDataStructureTimeTests[i].ReadTime(LoopType.Foreach);
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
    public abstract class DataStructureTimeTest
    {
        protected IStopwatchType iStopwatchType;
        protected long numberOfElements;        
        protected int number;
        protected delegate void TimeTestDelegate();
        protected DataStructureTimeTest()
        {
            iStopwatchType = new StopwatchType();
            numberOfElements = 10000000;
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
        private int[,] integerArray;
        public TimeSpan InstantiationTime()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(InstantiationTime_));
            return iStopwatchType.TimeElapsed;
        }
        private void InstantiationTime_()
        {
            integerArray = new int[numberOfElements, 2];
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
                integerArray[i, 0] = number;
                integerArray[i, 1] = number;
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
                number = integerArray[i, 1];
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
                number = i.Key;
                number = i.Value;
            }
        }
    }
    public class ListTimeTest : DataStructureTimeTest, IDataStructureTimeTest
    {
        private List<int[]> integerList;
        public TimeSpan InstantiationTime()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(InstantiationTime_));
            return iStopwatchType.TimeElapsed;
        }
        private void InstantiationTime_()
        {
            integerList = new List<int[]>();
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
                integerList.Add(new int[2] { number, number });
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
                number = integerList[i].ElementAt(1);
            }
        }
        private void ReadTimeForEach()
        {
            TimeTestDelegateMethod(new TimeTestDelegate(ReadTimeForEach_));
        }
        private void ReadTimeForEach_()
        {
            foreach (int[] i in integerList)
            {
                number = i.ElementAt(1);
            }
        }
    }
