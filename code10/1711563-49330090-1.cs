    class Example : MonoBehaviour, ISaveable
    {
    void Start(){
    SaveManager.Instance.AddSaveAble(this);
    }
    }
