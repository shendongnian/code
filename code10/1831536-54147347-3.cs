    public class FillInput: MonoBehaviour
    {
        [SerializeField] private FloatVariable floatReference;
        private AsyncOperation loadOperation;
        void LoadLevelAsync(string levelName)
        {
            this.loadOperation = SceneManager.LoadLevelAsync(levelName, LoadSceneMode.Additive);
        }
        void Update()
        {
            this.floatReference.value = this.loadOperation?.progress ?? 0;
        }
    }
