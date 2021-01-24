    void OnCollisionEnter(Collision collision) {
        GameObject data = GameObject.Find("Data");
        var treeList = data.GetComponent<DataStorage>().treeList;
        
        // compare references
        if (treeList.Contains(collision.gameObject)) {
            GameObject.Destroy(collision.gameObject);
            treeList.Remove(collision.gameObject);
        }
    }
