    void SpawnReplacementPlayer(string pickUpName, GameObject theObject)
    {
            Instantiate(Resources.Load("Switch", typeof(GameObject)));
            GUIJar.blood = false;
            GameObject clone;
            clone = Instantiate(Resources.Load(pickUpName, typeof(GameObject))) as GameObject;
            clone.transform.position = this.gameObject.transform.position;
            Object.Destroy(theObject);
            Object.Destroy(this.gameObject);
    }
