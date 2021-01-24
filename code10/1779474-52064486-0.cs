    //enum contains all your enemies
    public enum EnemyType
    {
        Enemy1,
        Boss
    }
    public class Enemies : MonoBehaviour
    {
        //This will be assigned in the inspector
        public EnemyType CurrentEnemyType;
        //You don't need them to be public since you are hardcoding them.
        private float MaxHp;
        private float Hp;
        void Awake()
        {
            AssignStats();
        }
        public void AssignStats()
        {
            if (gameObject.CompareTag(CurrentEnemyType.ToString()))
            {
                if (CurrentEnemyType == EnemyType.Enemy1)
                {
                    MaxHp = 50;
                    Hp = MaxHp;
                    Debug.Log(Hp);
                }
                // instead of doing separated if blocks, you need to do if else for less code execution
                else if (CurrentEnemyType == EnemyType.Boss) 
                {
                    MaxHp = 500;
                    Hp = MaxHp;
                    Debug.Log(Hp);
                }
            /*
             More simplified way instead of the if else, if you assume that all your enemies except the boss have 50 hp.
            MaxHp = CurrentEnemyType == EnemyType.Boss ? 500 : 50;
            Hp = MaxHp;
            Debug.Log(Hp);
            */
            }
        }
    }
