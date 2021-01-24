        bool inputBegan = false;
        Vector2 beganPosition;
        void Update()
        {
            if (!inputBegan && Input.GetMouseButtonDown (0))
            {
                inputBegan = true;
                beganPosition = Input.mousePosition;
            }
            else if (inputBegan && Input.GetMouseButtonUp (0))
            {
                //If you want a threshold you need to change this comparison
                if (beganPosition.x > Input.mousePosition) 
                {
                    MoveBallLeft ();
                }
                else
                {
                    MoveBallRight ();
                }
                inputBegan = false;
            }
        }
