        public static void Main()
        {
            myclass x = new myclass();
            x.myproperty = "test";
            Console.WriteLine(x.myproperty);
        }
        class myclass
        {
            string sample;
            public string myproperty
            {
                get { return sample; }
                set { sample = value; }
            }
        }
