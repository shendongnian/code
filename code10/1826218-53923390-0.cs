    public class UIController : MonoBehaviour, IComparer<Slot>
    {
    public static UIController instance;
    public Text uiMessageBox;
    public Slot[] slots;
    
    private void Awake()
    {
        slots = FindObjectsOfType<Slot>();
        Array.Sort(slots, this); // i just passed 'this' as the IComparer parameter :)
    }
    public int Compare(Slot x, Slot y)
    {
       return x.name.CompareTo(y.name);
    }
}
    
