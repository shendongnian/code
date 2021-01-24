    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace TrieQuestions
    {
        [TestClass]
        public class UnitTest2
        {
            //1st new of Dictionary
            IDictionary<string, string> test_dict= new Dictionary<string, string>();
            private String ping_msg;
            [TestMethod]
            public void TestMethod1()
            {
                test_dict = develop.AddPing(ping_msg);
                test_dict["NET_MSG"] = "Putting new message";
            }
        }
    
        public static class develop
        {
           
            public static IDictionary<string, string> AddPing(String message)
            {
                //another new instance of the dictionary is created!!
                IDictionary<string, string> new_ping = new Dictionary<string, string>();
                new_ping["NET_MSG"] = message;
                new_ping["IP"] = get_IP();
                new_ping["HOST"] = get_host();
    
                return new_ping;
            }
    
            private static string get_host()
            {
                return "host";
            }
    
            private static string get_IP()
            {
                return "ip";
            }
        }
    }
