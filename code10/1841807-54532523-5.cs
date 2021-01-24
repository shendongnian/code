        public class MyModel
        {
            [MyRequiredIfNot(typeof(MyController))]
            public string Name { get; set; }
        }
