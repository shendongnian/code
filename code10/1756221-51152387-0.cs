    class Program
    {
        static void Main(string[] args)
        {
            var number = 999;
    
            ScriptBuilder scriptStringBuilder = new ScriptBuilder();
            var text = scriptStringBuilder
                .WriteLine($"/!HEADSTART")
                .WriteLine($"/! TYPE = abc")
                .WriteLine($"/! NAME = name")
                .WriteLine($"/!HEADEND")
                .NewLine(2)
                .IfCondition(number != 999, ifCondition => {
                    ifCondition.NewLine(1);
                    ifCondition.WriteLine("SUCCESS");
                }, elseCondition => {
                    elseCondition.NewLine(1);
                    elseCondition.WriteLine("FAIL");
                }, 
                elseIf1 => elseIf1.ElseIfCondition(number > 1, h1 => h1.WriteLine("NUMBER IS BIGGER THAN 1")),
                elseIf2 => elseIf2.ElseIfCondition(number > 2, h2 => h2.WriteLine("NUMBER IS BIGGER THAN 2")))
                .Build();
    
            Console.WriteLine(text);
    
            Console.ReadKey();
        }
    }
    
    public class ScriptBuilder : IElseIfConditionable
    {
        private string _script;
    
        public ScriptBuilder NewLine(uint numberOfLines = 1)
        {
            if (numberOfLines == 0)
            {
                return this;
            }
            else
            {
                for (int i = 1; i <= numberOfLines; ++i)
                {
                    _script += Environment.NewLine;
                }
                return this;
            }
        }
        public ScriptBuilder WriteLine(string str = "")
        {
            if (str != "")
            {
                _script += str;
                NewLine();
            }
            return this;
        }
        public ScriptBuilder(string line = "")
        {
            _script = line;
            if (line != "")
            {
                NewLine();
            }
        }
        public ScriptBuilder SetLong(string longName, long x)
        {
            WriteLine("int " + longName + " " + x.ToString(System.Globalization.CultureInfo.InvariantCulture));
            return this;
        }
    
        public string Build()
        {
            return _script;
        }
    
        public ScriptBuilder IfCondition(bool condition, Action<ScriptBuilder> trueCondition, Action<ScriptBuilder> falseCondition, params Func<IElseIfConditionable, Tuple<ScriptBuilder, bool>>[] elseIfs)
        {
            if (condition)
            {
                trueCondition(this);
                return this;
            }
    
            foreach (var elseIf in elseIfs)
            {
                if (elseIf(this).Item2)
                {
                    return this;
                }
            }
    
            if (!condition)
            {
                falseCondition(this);
            }
    
            return this;
        }
    
        public Tuple<ScriptBuilder, bool> ElseIfCondition(bool condition, Action<ScriptBuilder> trueCondition)
        {
            if (condition)
            {
                trueCondition(this);
            }
    
            return Tuple.Create(this, condition);
        }
    }
    
    public interface IElseIfConditionable
    {
        Tuple<ScriptBuilder, bool> ElseIfCondition(bool condition, Action<ScriptBuilder> trueCondition);
    }
