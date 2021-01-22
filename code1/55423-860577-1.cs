    public class MyControl : Control
    {
        private readonly HashSet<RenderBehaviors> coll = new HashSet<RenderBehaviors>();
        public IEnumerable<RenderBehaviors> Behaviors { get { return coll; } }
        public string BehaviorsList
        {
            get { return string.Join(',', coll.Select(b => b.ToString()).ToArray()); }
            set
            {
                coll.Clear();
                foreach (var b in value.Split(',')
                    .Select(s => (RenderBehvaior)Enum.Parse(typeof(RenderBehavior), s)))
                {
                    coll.Add(b);
                }
            }
        }
    }
