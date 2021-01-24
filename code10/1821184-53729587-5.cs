    public class BroncoClass
    {
        private BroncoClass(int timeLeft, bool gravity, bool rotation)
        {
            Npc = new NPC();
            TimeLeft = timeLeft;
            Gravity = gravity;
            Rotation = rotation;
        }
        public NPC Npc { get; set; }
        public int TimeLeft { get; set; }
        public bool Gravity { get; set; }
        public bool Rotation { get; set; }
        private static List<BroncoClass> _instances = new List<BroncoClass>();
        public static BroncoClass Create(int timeLeft, bool gravity, bool rotation)
        {
            var bronco = new BroncoClass(timeLeft, gravity, rotation);
            _instances.Add(bronco);
            return bronco;
        }
        public static bool Remove(NPC npc)
        {
            var broncoFound = _instances.FirstOrDefault(b => b.Npc == npc);
            if (broncoFound == null)
            {
                return false;
            }
            _instances.Remove(broncoFound);
            return true;
        }
        public static BroncoClass Find(NPC npc)
        {
            return _instances.FirstOrDefault(b => b.Npc == npc);
        }
    }
