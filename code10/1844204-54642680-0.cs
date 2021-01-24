     public void OnMouseDown()
        {
            Debug.Log(senatorName + " is in chamber " + inChamber);
            rbSenator = GetComponent<Rigidbody2D>();
            string newChamber = chooseMove(inChamber);
            newPos = actMove(newChamber);
            inChamber = newChamber;
            rbSenator.transform.position = newPos;
            Debug.Log(senatorName + " is in chamber " + inChamber);
        }
