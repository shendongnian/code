    [WebMethod]
    [XmlInclude(typeof(ModelCar))]
    public object GetObjects(Cars[] cars)
    {
        return Translator.ToObjects(Facade.GetObjects(cars);
    }
