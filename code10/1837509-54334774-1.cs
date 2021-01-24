    [CreateAssetMenu(fileName = "New Character", menuName =
    "Characters/Soldier")]
    public class SoldierData : ScriptableObject
    {
        //public Weapon weapon;
        public float life = 100;
        public bool autoAttack = true;
        public Skills skills = new Skills();
    }
