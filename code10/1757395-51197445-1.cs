    public abstract class Input<T>
        {
            protected T __input;
            public abstract void Add(T c);
            public T GetValue()
            {
                return __input;
            }
        }
        public class NumericInput : Input<int>
        {
            public override void Add(int c)
            {
                __input += c;
            }
        }
        public class TextInput : Input<string>
        {
            public override void Add(string c)
            {
                __input += c;
            }
        }
    static void Main(string[] args)
            {
                var input = new NumericInput();
                input.Add(1);
                input.Add(2);
                Console.WriteLine(input.GetValue());
    
                var text = new TextInput();
                text.Add("a");
                text.Add("a");
                text.Add("a");
                Console.WriteLine(text.GetValue());
   
                Console.ReadLine();
            }
