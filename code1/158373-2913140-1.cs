        public struct TestStruct
        {
            public string value1;
            public string value2;
            public string value3;
            public string value4;
            public TestStruct(string value1, string value2, string value3, string value4)
            {
                this.value1 = value1;
                this.value2 = value2;
                this.value3 = value3;
                this.value4 = value4;
            }
        }
        [System.Web.Services.WebMethod]
        public static string[] MyMethod(string address)
        {
            string[] returnarray = new string[4];
            TestStruct struct;
            struct.value1 = "";
            struct.value2 = address;
            struct.value3 = "";
            struct.value4 = "/Unavailable.bmp";
            //if fail, return default values
                    returnstring.SetValue(struct.value1, 0);
                    returnstring.SetValue(struct.value2, 1);
                    returnstring.SetValue(struct.value3, 2);
                    returnstring.SetValue(struct.value4, 3);
                    return returnstring;
            //if succeed
                    struct.values = processed values;
                    set the values on returnstring
                    return returnstring;
            //else
                    struct.values = other processed values;
                    set the values on returnstring
                    return returnstring;
        }
