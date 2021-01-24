    [OnSerializing]
    void OnSerializingMethod(StreamingContext context)
    {
        if (listRespuestasEncuestas == null)
        {
            listRespuestasEncuestas = new List<RespuestasEncuesta>();
        }
        if (!listRespuestasEncuestas.Any())
        {
            //Add an empty item to the list.
        }
    }
    [OnSerialized]
    void OnSerializedMethod(StreamingContext context)
    {
        //if the list contains a single empty item, remove it and return the list to either empty or null.
    }
    
    [OnDeserialized]
    void OnDeserializedMethod(StreamingContext context)
    {
        //What to do if we receive a list with a single empty item? Do you want to keep it? Decide here.
    }
