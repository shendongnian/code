    public GameObject[] Obj ;
    // Using List here you can already initialize it here 
    // which would be possible using an array
    private List<bool> Status = new List<bool>();
    private List<MeshRenderer> rend = new List<MeshRenderer>();
    
    private void Start(){
        for (int i = 0; i < Obj.Length; i++)
        {
            rend.Add(Obj[i].GetComponentInChildren<MeshRenderer>());
            bool existsAndEnabled = rend[i] != null && rend[i].enabled;
            Status.Add(existsAndEnabled); 
        }
    }
