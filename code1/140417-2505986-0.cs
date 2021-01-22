    using System;
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    
    class TestModel
    {
        public DateTime Date { get; set; }
    }
    
    class Test
    {
        public void TestFunction()
        {
            IEnumerable<TestModel> _testModel = new TestModel[] { new TestModel() };
            var emp = _testModel.Where(m => m.Date == DateTime.Now).Select(m => m);
    
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var shortDigits = digits.Where((digit, index) => digit.Length < index);
        }
    }
