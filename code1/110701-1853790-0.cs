    [Serializable]
    public class FieldLogger : OnFieldAccessAspect {
        public override void OnGetValue(FieldAccessEventArgs eventArgs) {
            Console.WriteLine(eventArgs.InstanceTag);
            Console.WriteLine("got value!");
            base.OnGetValue(eventArgs);
        }
    
        public override void OnSetValue(FieldAccessEventArgs eventArgs) {
            int i = (int?)eventArgs.InstanceTag ?? 0;
            eventArgs.InstanceTag = i + 1;
            Console.WriteLine("value set!");
            base.OnSetValue(eventArgs);
        }
    
        public override InstanceTagRequest GetInstanceTagRequest() {
            return new InstanceTagRequest("logger", new Guid("4f8a4963-82bf-4d32-8775-42cc3cd119bd"), false);
        }
    }
