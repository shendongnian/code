    some_class
     {
         public GameObject dronePrefab;
         for (int i = 0; i < number_of_Drones; ++i)
         {
            // Step 1.
            drco = new Vector3((float)0, (float)1, (float)0);
            drones[i] = Instantiate(dronePrefab, drco, 
            Quaternion.Euler(-90, 0, 90)) as GameObject;
            // Steps 2 & 3
            drones_script[i] = drones[i].GetComponent<drone_script>();
            // Step 4
            drones_script[i].drone_subscriber = a unique value;            
        }
    }
