        public static void Show() {
            List<Person> people = new List<Person>();
            //Everything is done inside the loop
            PersonDal personDal = new PersonDal();
            foreach (Person person in people) {
                personDal.Insert(person);
            }
            //Things are setup once outside the loop.
            using (DbConnection connection = SqlClientFactory.Instance.CreateConnection()) {
                // setup the connection
                BetterPersonDal betterPersonDal = new BetterPersonDal(connection);
                connection.Open();
                foreach (Person person in people) {
                    betterPersonDal.Insert(person);
                }
            }
        }
    }
    class Person {
        public int Id { get; set; }
        public string Name { get; set; }
    }
