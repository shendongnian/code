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
        Button newBtn = Instantiate(btnPrefab, canvas.transform, false);
        newBtn.GetComponent<RectTransform>().anchoredPosition = // position you want...
        newBtn.GetComponentInChildren<Text>().text = i;
    }
