    // in the inspector here you set the target tag 
    // the player should collide with
    [SerializeField] private string _collideWithTag;
    private List<Collider> _colliders;
    private void Update()
    {
        if(_colliders.Count > 0) return;
        // not in a valid area -> fall or whatever
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != _collideWithTag) return;
        if(_colliders.Contains(other)) return;
        
        _colliders.Add(other);
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag != _collideWithTag) return;
        if(!_colliders.Contains(other)) return;
        
        _colliders.Remove(other);
    }
    // the above should be enough but you could go sure and also use
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag != _collideWithTag) return;
        if(_colliders.Contains(other)) return;
        
        _colliders.Add(other);
    }
