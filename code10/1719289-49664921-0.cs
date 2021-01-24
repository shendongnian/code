          public class helperclass
            {
                public string name;
                public int score;
                public string time; //dunno what is to be used for timer.
            }
            void Start()
                {
     GameObject timerobject= GameObject.Find("timerobject");
                helpmetimer  htimer= timerobject.GetComponent<helpmetimer>();
    
                    helperclass data = new helperclass() { name = "ravi", score =0 ,time=htimer.timerText.text };
                
                ...
    }
