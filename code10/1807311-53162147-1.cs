    // If this is true, we are already waiting 
    // and don't want more Wait coroutines (yet)
    private bool waiting;  
    void Start()
    {
        button1.onClick.AddListener(Heal20);
        button2.onClick.AddListener(Damage40);
        YH.text = Convert.ToString(yourHealth);
        EH.text = Convert.ToString(enemyHealth);
        waiting = false;
    }
    // ...
        if (yourTurn == false)
        {
            if (!waiting) 
            {
                // we only want to do this stuff the first frame we start waiting
                button1.interactable = false;
                waiting = true;
                StartCoroutine(Wait(2));
            }
        }
        else
        {
            button1.interactable = true;
        }
    // ...
    IEnumerator Wait(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        EnemyTurn();
        waiting = false;
    }
