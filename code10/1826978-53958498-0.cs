        public class MyTable
        {
            private Boolean myBool { get; set; }
            public int OracleNumber
            {
                get { return (myBool == false) ? 0 : -1; }
                set { myBool = (value == -1) ? myBool = true : myBool = false; }
            }
        }
