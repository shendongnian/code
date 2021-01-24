    public class ClickEvent : MonoBehaviour {
        public UnityEngine.Events.UnityEvent OnClick;
        public void Update() {
            if (Input.GetMouseButtonDown(0))
                OnClick.Invoke();
        }
    }
