    public enum TestStatus {
            Sucess,
            Error
                ///etc
        }
        public static class Ext {
        public static TestStatus ToTestStatus(this string target) {
            TestStatus testStatus;
            var enumerator = Enum.GetValues(typeof(TestStatus)).GetEnumerator();
            
            while (enumerator.MoveNext()) {
                if ((testStatus=((TestStatus)enumerator.Current)).ToString() == target) {
                    return testStatus;
                }
                    
            }
            return TestStatus.Error; //some default;
    
        }
    }
