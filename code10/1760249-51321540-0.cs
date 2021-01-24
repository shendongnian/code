    public class NameGenerator {
        private int _next;
        private readonly string _nameRoot;
        public NameGenerator(string nameRoot) : this (nameRoot, 0)
        {}
        public Namegenerator(string nameRoot, int firstNumber)
        {
            _next = firstNumber;
            _nameRoot = nameRoot;
        }
        public string NextName()
        {
            return String.Format("{0}_{1}", _nameRoot,_next++);
        }
    }
