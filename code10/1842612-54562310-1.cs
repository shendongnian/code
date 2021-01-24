    public class Engine : MonoBehaviour, ICarEquip
    {
        // Attach your CarBase information
        [System.Serializable]
        CarBase carBase;
        // Specific properties
        public bool doesSupportAddonExhaust;
        public int power;
        // Implement your interface methods
        public void Equip()
        {
        }
    }
