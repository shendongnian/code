    public abstract class Unit
    {
        protected abstract Dictionary<int, int> MaxHpByLevel { get; }
        public int Level { get; set; } = 1;
        public int MaxHp => this.MaxHpByLevel[this.Level];
    }
    public class Soldier : Unit
    {
        protected override Dictionary<int, int> MaxHpByLevel => new Dictionary<int, int>
        {
            [1] = 5,
            [2] = 6,
            [3] = 8
        };
    }
    public class Mage : Unit
    {
        protected override Dictionary<int, int> MaxHpByLevel => new Dictionary<int, int>
        {
            [1] = 3,
            [2] = 4,
            [3] = 5
        };
    }
