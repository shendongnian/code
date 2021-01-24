    public interface IEnviromentVariables {
        string getEnVariable(string variable);
    }
    public class EnviromentClass : IEnviromentVariables {
        public string getEnVariable(string variable) {
            return System.Environment.GetEnvironmentVariable(variable);
        }
    }
