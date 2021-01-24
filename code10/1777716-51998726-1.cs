    public class Monster : Character {  
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Player") {
                BattleController.SetEnemy(enemyName, enemyID)
                SceneManager.LoadScene("Battle");
            }
        }
    }
