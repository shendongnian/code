    public class FillInput: MonoBehaviour
    {
        [SerializeField] private FloatVariable floatReference;
        [SerializeField] private Input input;
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Enter))
            {
                this.floatReference.value = float.Parse(input.text)/100f;
            }
        }
    }
