    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.UI;
    
    public class NumberWizard : MonoBehaviour {
    
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;
    
    int guess;
    int lastGuess;
    
    // Use this for initialization
    void Start ()
    {
        StartGame();
    }
    
    void StartGame()
    {
        NextGuess();
    }
    
    public void OnPressHigher()
    {
        min = guess + 1;
        NextGuess();
    }
    
    public void OnPressLower()
    {
        max = guess - 1;
        NextGuess();
    }
    
    void NextGuess()
    {
        lastGuess = guess;
        guess = Random.Range(min, max+1);
        guessText.text = guess.ToString();
    }
    
    public void Back()
    {
        guess = lastGuess;
        guessText.text = guess.ToString();
    }
    }
