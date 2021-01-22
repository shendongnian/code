    class SuperFilter : Filter
    {
        private object more, parameters, here;
        public SuperFilter(object more, object parameters, object here)
        {
            this.more = more;
            this.parameters = parameters;
            this.here = here;
        }
        override protected List<account> Filter(selected, u, r, countNeeded)
        {
            // use more parameters here along with the regular parameters
        }
        ...
    }
