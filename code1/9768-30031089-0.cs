    public abstract class ReleaseContainer<T>
    {
        private readonly Action<T> actionOnT;
        protected ReleaseContainer(T releasible, Action<T> actionOnT)
        {
            this.actionOnT = actionOnT;
            this.Releasible = releasible;
        }
        ~ReleaseContainer()
        {
            Release();
        }
        public T Releasible { get; private set; }
        private void Release()
        {
            actionOnT(Releasible);
            Releasible = default(T);
        }
    }
