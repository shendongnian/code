    using UnityEngine;
    using System.Collections;
    public class Pacdot : MonoBehaviour {
        public int score = 10;
        private ScoreManager _score = GameObject.findGameObjectWithTag("scoreKeeper").GetComponent<ScoreManager>();
        void OnTriggerEnter2D(Collider2D co) {
            if (co.name == "pacman")
            {           
                _score.SetScore(score);
                Destroy(gameObject);
            }
        }
    }
