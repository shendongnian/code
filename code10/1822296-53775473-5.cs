    // Store the component frerence instead of getting it everytime again
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            Debug.Log("t is being pressed");
            _animator.SetBool("IsOpen", true);
        }
        // use if-else in order to process only one of the buttons at a time
        else if (Input.GetKeyDown("u"))
        {
            Debug.Log("u is being pressed");
            _animator.SetBool("IsOpen", false);
        }
        // you still can keep those for jumping to a state directly without the transition
        else if (Input.GetKeyDown("x"))
        {
            _animator.Play("Opened");
        }
        else if (Input.GetKeyDown("z"))
        {
            _animator.Play("Closed");
        }
    }
