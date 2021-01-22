    public class MyAssert
        {
            public class AssertAnswer
            {
                public bool Success { get; set; }
                public string Message { get; set; }
            }
    
            public static void Throws<T>(Action action, string expectedMessage) where T : Exception
            {
                AssertAnswer answer = AssertAction<T>(action, expectedMessage);
    
                Assert.IsTrue(answer.Success);
                Assert.AreEqual(expectedMessage, answer.Message);
            }
    
            public static void AreEnumerableSame(IEnumerable<object> enumerable1, IEnumerable<object> enumerable2)
            {
                bool isSameEnumerable = true;
                bool isSameObject ;
    
                if (enumerable1.Count() == enumerable2.Count())
                {
                    foreach (object o1 in enumerable1)
                    {
                        isSameObject = false;
                        foreach (object o2 in enumerable2)
                        {
                            if (o2.Equals(o1))
                            {
                                isSameObject = true;
                                break;
                            }
                        }
                        if (!isSameObject)
                        {
                            isSameEnumerable = false;
                            break;
                        }
                    }
                }
                else
                    isSameEnumerable = false;
    
                Assert.IsTrue(isSameEnumerable);
            }
    
            public static AssertAnswer AssertAction<T>(Action action, string expectedMessage) where T : Exception
            {
                AssertAnswer answer = new AssertAnswer();
    
                try
                {
                    action.Invoke();
    
                    answer.Success = false;
                    answer.Message = string.Format("Exception of type {0} should be thrown.", typeof(T));
                }
                catch (T exc)
                {
                    answer.Success = true;
                    answer.Message = expectedMessage;
                }
                catch (Exception e)
                {
                    answer.Success = false;
                    answer.Message = string.Format("A different Exception was thrown {0}.", e.GetType());
                }
    
                return answer;
            }
        }
