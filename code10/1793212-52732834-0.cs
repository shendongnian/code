    public class Toast : MonoBehaviour {
    public Button btn;
    public Text txt;
	// Use this for initialization
    void Start()
    {
        txt.enabled = false;
    }
	// Update is called once per frame
	void Update () 
    {
		
	}
    //Button click function
    public  void Show()
    {
        if (txt.isActiveAndEnabled)
        {
            txt.enabled = false;
            btn.GetComponentInChildren<Text>().text = "Show";
        }
        else
        {
            txt.enabled = true;
            btn.GetComponentInChildren<Text>().text = "Hide";
        }
    }
    }
