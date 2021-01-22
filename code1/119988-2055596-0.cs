        public interface IRoo : IBindableComponent { }
        public interface ISoo { }
        public interface IMoo { }
        public interface IGoo { }
        public interface IFoo { }
        public interface IBar : IFoo { }
        public class Bar : IBar { }
        private void button1_Click(object sender, EventArgs e)
        {
            Type[] interfaces  = typeof(Bar).GetInterfaces();
            Type immediateInterface = GetPrimaryInterface(interfaces);
            //immediateInterface = {Name = "IFoo" ... }
        }
        public Type GetPrimaryInterface(Type[] interfaces)
        {
            if (interfaces.Length == 0) return null;
            if (interfaces.Length == 1) return interfaces[0];
            Dictionary<Type, int> typeScores = new Dictionary<Type, int>();
            foreach (Type t in interfaces)
            {
                typeScores.Add(t, 0);
                foreach (Type t1 in interfaces)
                {
                    if (t.IsAssignableFrom(t1))
                        typeScores[t]++;
                }
            }
            Type winner = null;
            int bestScore = -1;
            foreach (KeyValuePair<Type, int> pair in typeScores)
            {
                if (pair.Value > bestScore)
                {
                    bestScore = pair.Value;
                    winner = pair.Key;
                }
            }
            return winner;
        }
