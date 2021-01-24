        public class HumanWarrior : IWarrior
        {
            public string Name { get; private set; }
    
            public void Init(string name)
            {
                Name = name;
            }
        }
