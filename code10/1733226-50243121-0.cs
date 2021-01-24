    public static void eatSomeBananas(IEnumerable<XmlNode> subBananaNodeList, int numberOfBananas)
    {
        IEnumerable<XmlNode> bananasToEat = subBananaNodeList.Take(numberOfBananas);
        IEnumerable<XmlNode> remainingBananas = subBananaNodeList.Skip(numberOfBananas);
        // Added condition to avoid infinite recursion
        if (remainingBananas.Any())
        {
            eatSomeBananas(remainingBananas, numberOfBananas);
        }
    }
