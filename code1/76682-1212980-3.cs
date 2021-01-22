        [Serializable]
        public class Animal
        {
            public string Home { get; set; }
        }
        
        [Serializable]
        public class Person
        {
            public string Name { get; set; }
        }
        public void ExampleUsage() {
            List<Object> SerializeMeBaby = new List<Object> {
                new Animal { Home = "London, UK" },
                new Person { Name = "Skittles" }
            };
            string TargetPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Test1.dat");
            SerializeList(SerializeMeBaby, TargetPath);
        }
