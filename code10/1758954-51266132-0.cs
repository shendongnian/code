    public void AddCardToOppositeHand(Card card)
        {
            GameObject cardUI = Instantiate(UtilFuncs.GetAssetHolder().card);
            cardUI.GetComponent<CardVisible>().LoadCard(card, true);
            cardUI.transform.SetParent(gameObject.transform, true);
            Pair<Card, GameObject> pair = new Pair<Card, GameObject>(card, cardUI);
            AddToDictionary(pair);
            reSizeHand();
        }
        public void reSizeHand()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 1);
                transform.GetChild(i).GetComponent<RectTransform>().localPosition = new Vector3(transform.GetChild(i).GetComponent<RectTransform>().localPosition.x, transform.GetChild(i).GetComponent<RectTransform>().localPosition.y, 0);
            }
        }
