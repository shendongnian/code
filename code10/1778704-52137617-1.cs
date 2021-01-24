    public class BoardManager : NetworkBehaviour
    {
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    public GameObject[] Buttons;
    public Sprite[] Sprites;
    public void SetButton(int index)
    {
        GameObject img = GameObject.Find("X");
        img.GetComponent<Image>().sprite = Sprites[0];
    }
