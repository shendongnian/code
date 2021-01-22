    class Program {
        static void Main(string[] args) {
            var assembly = Assembly.GetExecutingAssembly();
            IDictionary<byte, Func<Message>> messages = assembly
                .GetTypes()
                .Where(t => typeof(Message).IsAssignableFrom(t) && !t.IsAbstract)
                .Select(t => new {
                    Keys = t.GetCustomAttributes(typeof(AcceptsAttribute), true)
                           .Cast<AcceptsAttribute>().Select(attr => attr.MessageId),
                    Value = (Func<Message>)Expression.Lambda(
                            Expression.Convert(Expression.New(t), typeof(Message)))
                            .Compile()
                })
                .SelectMany(o => o.Keys.Select(key => new { Key = key, o.Value }))
                .ToDictionary(o => o.Key, v => v.Value); 
                //will give you a runtime error when created if more 
                //than one class accepts the same message id, <= useful test case?
            var m = messages[5](); // consider a TryGetValue here instead
            m.Accept(new Packet());
            Console.ReadKey();
        }
    }
    [Accepts(5)]
    public class FooMessage : Message {
        public override void Accept(Packet packet) {
            Console.WriteLine("here");
        }
    }
    //turned off for the moment by not accepting any message ids
    public class BarMessage : Message {
        public override void Accept(Packet packet) {
            Console.WriteLine("here2");
        }
    }
    public class Packet {}
    public class AcceptsAttribute : Attribute {
        public AcceptsAttribute(byte messageId) { MessageId = messageId; }
        public byte MessageId { get; private set; }
    }
    public abstract class Message {
        public abstract void Accept(Packet packet);
        public virtual Packet Create() { return new Packet(); }
    }
