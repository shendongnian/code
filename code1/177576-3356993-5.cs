    using System.Xml;
    using System.Xml.Serialization;
    //...
    ShoppingCart shoppingCart = FetchShoppingCartFromSomewhere();
    var serializer = new XmlSerializer(shoppingCart.GetType());
    using (var writer = XmlWriter.Create("shoppingcart.xml"))
    {
        serializer.Serialize(writer, shoppingCart);
    }
