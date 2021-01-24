    using System.Collections;
    using UnityEngine;
    
    public class NewBehaviourScript : MonoBehaviour {
    
        public float waitTime = 10.0f;
        public float fadeTime = 3.0f;
        public float betweenFadesTime = 2.0f;
    
        // Flag to determine whether or not the player may respond.
        public bool canRespond = false;
    
        // Flag to determine if the player has responded within the wait time.
        public bool hasResponded = false;
    
        public GameObject enemy;
    
        void Start()
        { StartCoroutine(EnemyFadeIn(fadeTime, betweenFadesTime, waitTime)); }
    
        void Update() {
            if ((Input.GetKeyDown(KeyCode.S)) && (canRespond))
            { hasResponded = true; }
        }
    
        IEnumerator EnemyFadeIn(float timeToFade, float timeBetweenFades, float timeToWait) {
            Debug.Log("An Enemy Is Fading In");
            // Simulating Fade In Time.
            yield return new WaitForSeconds(timeToFade);
            // Fade in
            // iTween.FadeTo(enemy, 1, 1);
            // Invoke("SetMaterialOpaque", 1f);
            Debug.Log("An Enemy Has Appeared");
    
            yield return ListenForInput(timeToFade, timeBetweenFades, timeToWait);
        }
    
        IEnumerator EnemyFadeOut(float timeToFade, float timeBetweenFades, float timeToWait) {
            Debug.Log("An Enemy Is Fading Away");
            // Simulating Fade Out Time.
            yield return new WaitForSeconds(timeToFade);
            // Fade out
            // SetMaterialTransparent();
            // iTween.FadeTo(enemy, 0, 1);
            Debug.Log("An Enemy Has Departed");
            // Simulating Time Between Fades.
            yield return new WaitForSeconds(timeBetweenFades);
    
            yield return EnemyFadeIn(timeToFade, timeBetweenFades, timeToWait);
        }
    
        // Responsible for reacting to the 'S' key input.
        IEnumerator ListenForInput(float timeToFade, float timeBetweenFades, float timeToWait) {
            canRespond = true;
            Debug.Log("Press the 'S' Key to Destroy the Enemy!");
            float startTime = Time.time;
    
            // Check every 0.25 seconds to see if the S key was pressed.
            while (Time.time < (startTime + timeToWait)) {
                if (hasResponded) {
                    Debug.Log("The 'S' Key was Pressed!");
                    hasResponded = false;
                    canRespond = false;
                    yield return EnemyFadeOut(timeToFade, timeBetweenFades, timeToWait);
                }
                yield return new WaitForSeconds(0.25f);
            }
    
            Debug.Log("The 'S' Key was not Pressed!");
            canRespond = false;
            yield return ResetGame();
        }
    
        IEnumerator ResetGame() {
            Debug.Log("Game is Performing a Reset");
            //Simulating Game Reset Time.
            yield return new WaitForSeconds(10);
            Debug.Log("Game has Restarted. End of Coroutine!");
        }
    }
I created the EnemyFadeOut() and ListenForInput() methods to accompany the EnemyFadeIn() and ResetGame() methods. These are your four states. The behaviour flows as follows:
First, the Start() Monobehaviour starts the EnemyFadeIn() coroutine.
Next, the EnemyFadeIn() coroutine will pass control over to ListenForInput() upon fully phasing the enemy into the game world. 
Next, the ListenForInput() coroutine will pass control over to either EnemyFadeOut() if the 'S' key was pressed within the given waitTime, or ResetGame() if the 'S' key was not pressed in time.
If control is passed to EnemyFadeOut(), the enemy will phase out of the world, and then control will pass to EnemyFadeIn() and the cycle will continue until the player fails to press the 'S' key.
If control is passed to ResetGame(), then the player has failed to press the 'S' key in time, and the game will perform all necessary functions to restart.
Console Debug.Log() and yield return new WaitForSeconds() are used for simulation purposes. Since iTween is not a native library on my end, some Fade In/Out code had to be commented out.
