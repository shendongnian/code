    public abstract class Algorithm {
    }
    
    public class AlgorithmA : Algorithm { }
    public class AlgorithmB : Algorithm { }
    
    public interface IAlgorithmFactory
    {
        string Name {get;}
        Algorithm GetAlgorithm();
    }
    
    public class AlgorithmFactory<T> : IAlgorithmFactory where T : Algorithm, new()
    {
        public string Name {get { return typeof(T).Name; }}
        public Algorithm GetAlgorithm()
        {
            return new T();
        }
    }
    
    public class Client {
        public void MyLib(IEnumerable<IAlgorithmFactory> algorithms) {
            
        // ... Check they all derive from Algorithm
        }
    
        public void Communicate() {
        // ... Send list of algorithm names to server
        // ... Create instance of algorithm dictated by server response
        }
    }
