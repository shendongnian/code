    Using UnityEngine;
    Using UnityEngine.UI;
    Using System;
    Using System.Generics;
    //Manager class for a collection of cards.
    public CardManager{
    [Header("Cards")] //sets a header in the inspector.
    public Transform CardParent; //Would be great to be a scroll views content for scrolling.
    public GameObject CardPrefab; //A UI button prefab
    public List<CardInfo> Cards; //List of your cards, set in the inspector.
    
    public void SpawnCards() //Sets up all cards.
    {
    foreach(var card in Cards){
    GameObject c = Instantiate(CardPrefab, CardParent); //Instantiate card with parent UI object.
    Image img = c.GetComponent<Image>(); 
    img.sprite = c.CardImageNotSelected; //Set card image.
    c.name = CardName + CardNumber; //Set GameObject name.
    Button btn = c.GetComponent<Button>();
    btn.onClick.AddListener(() => ToggleCardSelect(card, img)); //Sets up what happens when you click a card.
    //I did so that when you click the card it toggles the image between 2.
    }
    }
    
    void ToggleCardSelect(CardInfo card, Image img){
        card.CurrentlySelected = !card.CurrentlySelected; //Toggle boolean.
    if (card.CurrentlySelected)
    {
    //Deselect if already selected.
    img.sprite = CardImageNotSelected;
    }
    else
    {
    //Select
    img.sprite = CardImageSelected;
    }
    }
    }
    //CardInfo represents a single card.
    [System.Serializable] //allows a cardInfo to be viewable in a list in the inspector without being a simple property or inheriting monobehaviour.
    public CardInfo{
    public string CardName;
    public int CardNumber;
    public sprite CardImageSelected;
    public sprite CardImageNotSelected;
    public bool CurrentlySelected;
    }
