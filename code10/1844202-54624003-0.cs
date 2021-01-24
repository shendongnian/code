        public void OnMouseDown()
        {
            Debug.Log(senatorName + " is in chamber " + inChamber);
            newPos = new Vector3(0, 0, -2);
            transform.position = newPos;            
        }
