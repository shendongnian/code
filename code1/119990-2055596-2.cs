    public interface IRoo { }
    public interface ISoo : IRoo { }
    public interface IMoo : ISoo { }
    public interface IGoo : IMoo { }
    public interface IFoo : IGoo { }
    public interface IBar : IFoo { }
    public class Bar : IBar { }
    
    private void button1_Click(object sender, EventArgs e) {
        Type[] interfaces = typeof(Bar).GetInterfaces();    
        Type immediateInterface = GetPrimaryInterface(interfaces);
        // IBar
    }
    
    public Type GetPrimaryInterface(Type[] interfaces)
    {
        if (interfaces.Length == 0) return null;
        if (interfaces.Length == 1) return interfaces[0];
    
        Dictionary<Type, int> typeScores = new Dictionary<Type, int>();
        foreach (Type t in interfaces)
            typeScores.Add(t, 0);
    
        foreach (Type t in interfaces)
            foreach (Type t1 in interfaces)
                if (t.IsAssignableFrom(t1))
                    typeScores[t1]++;
    
        Type winner = null;
        int bestScore = -1;
        foreach (KeyValuePair<Type, int> pair in typeScores) {
            if (pair.Value > bestScore) {
                bestScore = pair.Value;
                winner = pair.Key;
            }
        }
        return winner;
    }
