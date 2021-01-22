    public class Disposer : Component
        {
            private readonly Action<bool> disposeAction;               
    
            public Disposer(Action<bool> disposeAction)
            {
                this.disposeAction = disposeAction;
            }
    
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
                this.disposeAction(disposing);
            }
    
            public static Disposer Register(ref IContainer container, Action<bool> disposeAction)
            {
                Disposer disposer = new Disposer(disposeAction);
                if (container == null)
                    container = new System.ComponentModel.Container();
    
                container.Add(disposer);
                return disposer;
            }
        }
