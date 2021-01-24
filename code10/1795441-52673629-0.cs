    public class Person {
        public string Name {get; set;}
        public int Age {get; set;}
        public Person(string name, int age) {
            this.Name = name;
            this.Age = age;
        }
    }
    DatabaseReference root = FirebaseDatabase.DefaultInstance.RootReference;
    var json = JsonUtility.ToJson(new Person("ltmenezes", 22));
    root.Child("test1").Child("test2").SetValueAsync(json);
