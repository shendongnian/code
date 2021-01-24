    public class Person
    {
        private string _name;
        private string _surname;
        private string _nickname;
        public string Name { get => _name; set { _name = value; NameInitialized = true; } }
        public bool NameInitialized { get; private set; }
        public string Surname { get => _surname; set { _surname = value; SurnameInitialized = true; } }
        public bool SurnameInitialized { get; private set; }
        public string Nickname { get => _nickname; set { Nic _nickname = value; NicknameInitialized = true; } }
        public bool NicknameInitialized { get; private set; }
        public Person GetPersonData()
        {
            return new Person()
            {
                Name = "Chris",
                Surname = "Topher"
            };
        }
    }
