    public class House : Building {
        public static int CAPACITY = 5;
        private List<Human> habitants;
    
        public List<Human> Habitants
        {
            get { return habitants; }
            set { habitants = value; }
        }
        public House() {
            habitants = new List<Human>();
        }
        public void AddHuman(Human human)
        {
            human.HasAHouse = true;
            habitants.Add(human);
            Game.currentAmount++;
        }
    }
