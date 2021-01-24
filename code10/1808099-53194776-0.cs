    public abstract class BaseSubscriber: MonoBehaviour, IBallManager
    {
        public virtual void OnEnable()
        {
            Publisher.OnClicked += OnPublisherClicked;
        }
    
        public virtual void OnDisable()
        {
            Publisher.OnClicked -= OnPublisherClicked;
        }
    
        protected abstract void OnPublisherClicked();
    }
