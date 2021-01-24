    // Don't start another sort while the current isn't finished
    // Or: stop the current one with StopAllCoroutines()
    bool isSorting = false;
    
    public void TaskOnClick()
    {
        if(isSorting == false)
        {
            isSorting = true;
            StartCoroutine(PerformInsertionSort());
        }
    }
    
    private IEnumerator PerformInsertionSort()
    {
        for(int i = 0; i < Balls.Length - 1; i++)
        {      
            if (string.Compare(Balls[i].name, Balls[i+1].name) > 0)                   
            {
                GameObject temp = Balls[i];
                Balls[i] = Balls[i+1];
                Balls[i+1] = temp;
        
                posA = Balls[i].gameObject.transform.position;
                posB = Balls[i + 1].gameObject.transform.position;
                Balls[i].gameObject.transform.position = posB;
                Balls[i + 1].gameObject.transform.position = posA;
                // If you want to wait only after a switch actually happend,
                // wait here.
            }
                
            // This is where you need to wait:
            yield return new WaitForSeconds(1f);
        }
    
        isSorting = false;
    }
