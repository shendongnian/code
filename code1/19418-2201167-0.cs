    [DataContract]
    public class MyClassWithSpecialInitialization
    {
        List<string> myList;
        string str1;
        [DataMember]
        public string Str1
        {
            get { return str1; }
            set
            {
                this.myList.Add(value);
                str1 = value;
            }
        }
        string str2;
        [DataMember]
        public string Str2
        {
            get { return str2; }
            set
            {
                this.myList.Add(value);
                str2 = value;
            }
        }
        public MyClassWithSpecialInitialization()
        {
            this.myList = new List<string>();
        }
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            Console.WriteLine("Before deserializing the fields");
            this.myList = new List<string>();
        }
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            Console.WriteLine("After deserializing the fields... myList should be populated with the values of str1 and str2");
        }
    }
