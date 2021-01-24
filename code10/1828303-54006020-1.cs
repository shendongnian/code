    [RequireComponent(typeof(Button))]
    public class ClickCounter : MonoBehaviour
    {
        public int CounterValue = 0;
        private Button _button;
        private void Awake()
        {
            _button.onClick.AddListener(() => 
            {
                CounterValue ++;
            }
        }
    }
