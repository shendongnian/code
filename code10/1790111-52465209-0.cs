    public interface ICollectableParent<out T> : ICollectableRelatedMonoBehaviour where T : Collectable
    {
        // This is allowed - T is used as a return type
        T GetChild();
        // This is *not* allowed - T is used as a parameter
        SetChild(T child);
    }
