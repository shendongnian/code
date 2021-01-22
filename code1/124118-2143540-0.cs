    abstract class Whatever : IFooable {
        public virtual void Do () {
            PreDo();
        }
        protected abstract void PreDo();
    }
