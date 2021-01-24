    class Toolbox
    {
        public readonly List<Location,List<Tool>> Store = new List<Location,List<Tool>>();
        public Toolbox(params Tool[] tool)
        {
            foreach (Tool t in tool)
                this.Store[t.Location].Add(t);
        }
    }
