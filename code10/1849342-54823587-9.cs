    public TextMesh WallText;
    private void Start()
    {
        WallText = GameObject.Find("WallText").GetComponent<TextMesh>();
        RandText();
    }
    public void RandText()
    {
        word = Strings[Random.Range(0, Strings.Length)];
        WallText.text = word;
    }
