    using UnityEngine.UI;
    ....
    public Canvas canvas
    public Button btnPrefab;
    ....
    string webResults = www.text;
    char seprator = '\t';
    string[] myStringArray = webResults.Split(seprator);
        
    foreach(string i in myStringArray)
    {
        Button newBtn = Instantiate(btnPrefab, canvas.transform);
        newBtn.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        newBtn.GetComponent<RectTransform>().position = // position you want...
        newBtn.GetComponentInChildren<Text>().text = i;
    }
