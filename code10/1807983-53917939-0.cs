    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class GameController : MonoBehaviour
    {
    
        public GameObject [] Hazards;
        public Vector3 SpawnValues;
        public int HazardCount;
        public float SpawnWait;
        public float StartWait;
        public float WaveWait;
        public GUIText ScoreText;
        private int Score;
        public GUIText RestartText;
        public GUIText GameOverText;
        public bool GameOver;
        private bool Restart;
        public List<int> Lista_Array;
        public int[] arr = { 0, 1, 2, 3, 4, 5 };
    
        IEnumerator SpawnWaves()
        {
    
            yield return new WaitForSeconds(StartWait);
            while (true)
            {
                for (int i = 0; i < HazardCount; i++)
                {
    				GameObject Hazard = Hazards[UnityEngine.Random.Range(0, Hazards.Length)];
                    Vector3 SpawnPosition = new Vector3(UnityEngine.Random.Range(-SpawnValues.x, SpawnValues.x), SpawnValues.y, SpawnValues.z);
                    Quaternion SpawnRotation = Quaternion.identity;
                    Instantiate(Hazard, SpawnPosition, SpawnRotation);
                    yield return new WaitForSeconds(SpawnWait);
                }
                yield return new WaitForSeconds(WaveWait);
    
                if (GameOver)
                {
    				RestartText.text = "Press 'B' to return to main menu or 'R' to restart";
                    Restart = true;
                    break;
                }
            }
    
        }
    
        public void UpdateScore()
        {
            ScoreText.text = "Score: " + Score;
            for (int i = 0; i < 1; i++)
            {
                //Lista_Array = new List<int>(Score);
                Lista_Array.Insert(0, Score);
                Lista_Array.Insert(0, 0);
                Lista_Array.Insert(0, 999);
                Lista_Array.Insert(0, 1999);
                Lista_Array.Insert(0, 2999);
                Lista_Array.Insert(0, 3999);
                arr = Lista_Array.ToArray();
                Lista_Array = new List<int>(Score);
                BubbleSort(arr);
                //Array.Sort(arr);
                //Lista_Array = arr.ToList();
                //Array_Lista = Lista_Array.ToArray();
            }
        }
    
        public int BuscaBinaria(int[] arr, int l, int r, int x)
        {
            if (r >= 1)
            {
                int mid = (r + l) / 2;
                if (arr[mid] == x)
                {
                    return mid;
                }
                if (arr[mid] < x)
                {
                    return BuscaBinaria(arr, 0, mid - 1, x); //aqui tbm
                }
                return BuscaBinaria(arr, mid + 1, r, x); //aqui tbm
            }
            return -1; //Aqui era -1
        }
    
        public static int[] BubbleSort(int[] arr1)
        {
            int length = arr1.Length;
    
            int temp = arr1[1];
    
            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (arr1[i] < arr1[j]) //mudei aqui
                    {
    
                            temp = arr1[i];
    
                            arr1[i] = arr1[j];
    
                            arr1[j] = temp;
                    }
                }
            }
    
            return arr1;
        }
    
        public void AddScore(int NewScoreValue)
        {
            Score += NewScoreValue;
            UpdateScore();
        }
    
        public void gameOver()
        {
            int n = arr.Length;
            int x = Score;
            int result = BuscaBinaria(arr, 0, n - 1, x);
            if (result == -1)
            {
                Debug.Log("Posicao nao encontrada");
            }
            else
            {
                Debug.Log("Posicao encontrada no Ranking " + result);
            }
            GameOverText.text = "Game Over";
            GameOver = true;
        }
    
        public void Start()
        {
            GameOver = false;
            Restart = false;
            RestartText.text = "";
            GameOverText.text = "";
            Score = 0;
            StartCoroutine(SpawnWaves());
            UpdateScore();
        }
    
        void Update()
        {
    		if(Restart){
    			if(Input.GetKeyDown (KeyCode.B)){
    				SceneManager.LoadScene ("Menu");
    			}
    		}
    
    		if(Restart){
    			if(Input.GetKeyDown (KeyCode.R)){
                    //Application.LoadLevel (Application.loadedLevel);
                    SceneManager.LoadScene("Main");
                }
    		}
    
        }
    
    }
