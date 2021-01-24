    public class Toast : MonoBehaviour {
    public Button btnShowHide;
    public Text txt;
	// Use this for initialization
    void Start()
    { 
        //Text to be shown
        txt.enabled = false;
     //If using a button with name "Show"
     btnShowHide.GetComponentInChildren<Text>().text = "Show";
    }
    //Button click function
    public  void Show()
    {
        if (txt.isActiveAndEnabled)
        {
            txt.enabled = false;
            btnShowHide.GetComponentInChildren<Text>().text = "Show";
        }
        else
        {
            txt.enabled = true;
            btnShowHide.GetComponentInChildren<Text>().text = "Hide";
        }
    }
    }
