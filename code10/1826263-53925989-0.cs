    internal class BaseClass {
        protected virtual void Info(){
            this.FinalInfo();
        }
        protected void FinalInfo() {
            Console.WriteLine("BaseClass");
        }
        internal virtual void CallInfo() {
            this.FinalInfo();
        }
    }
