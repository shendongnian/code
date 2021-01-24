    public interface IIntfacable : IDestroyable
    {
        void DoSomething();
    }
    public interface IDestroyable
    {
        void DestroyComponent();
        bool IsDestroyed { get; }
    }
    public class foo : MonoBehaviour, IIntfacable
    {
        bool IsDestroyed { get; private set; }
        public void DoSomething()
        {
            Debug.Log("=> DoSomething");
        }
        public void DestroyComponent()
        {
            Debug.Log("=> DestroyComponent");
            Destroy(gameObject);
        }
 
        public override OnDestroy() {
          base.OnDestroy();
          IsDestroyed = true; 
        }
    }
