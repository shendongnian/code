     private float myFloat = 10f;
     [SerializeField] private Button button = null;
     void Start( )
     {
         button.onClick.AddListener(MyMethod);
         DestroyImmediate(this.gameObject);
     }
     public void MyMethod()
     {
         Debug.Log("Call " + this.myFloat);
         this.myFloat ++;
     }
