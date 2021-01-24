        class Player
        {
          private static List<int> shirtNumbers = new List<int>();
           private int _shirtNo;
        public void PrintPlayerInfo() 
        {
            Console.WriteLine("Player: {0} {1}", Name, LastName);
            Console.WriteLine("Position: {0}", Position);
            Console.WriteLine("Shirt No.: {0}\n", _shirtNo);
        }
        public Player()
        {
            Name = string.Empty;
            LastName = string.Empty;
            Position = string.Empty;
            ShirtNo = 0;  
        }
        public Player(string name, string lastName, string position, int shirtNo)
        {
            Name = name;
            LastName = lastName;
            Position = position;
            ShirtNo = shirtNo;
            AddToList(_shirtNo);
        }
        private void AddToList(int newNumber)
        {
            shirtNumbers.Add(newNumber);
            Console.WriteLine(shirtNumbers[0]);
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public int ShirtNo
        {
            get { return _shirtNo; }
            set
            {
                if (shirtNumbers.Contains(value) == false)
                {
                    _shirtNo = value;
                }
                else
                {
                    _shirtNo = 0;
                }
            }
        }
    }
