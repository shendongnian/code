    private Vector3 bladeLastPos;
    private void Start(){
        bladeLastPos = new Vector3(blade.position.x,blade.position.y,blade.position.z); 
    }
    private void Update()
    {
        Vector2 v1 = new Vector2(this.transform.position.x, this.transform.position.y);
        Vector2 v2 = new Vector2(bladeLastPos.x, bladeLastPos.y);
        float maxRange = Vector2.Distance(v1,v2);
        RaycastHit2D[] hits = Physics2D.RaycastAll(v1, v2 - v1, maxRange);
        for (int i = 0; i < hits.Length; i++)
        {
            if (!hits[i].transform.GetComponent<ScriptNameInFruitWhereCutIs>().cut)
            {
                //Cut!
            }
        }
        bladeLastPos = new Vector3(transform.position.x,transform.position.y,transform.position.z); 
    }
