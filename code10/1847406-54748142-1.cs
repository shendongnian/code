        using Newtonsoft.Json;
        // ...
        String jsonText = wr.downloadHandler.text;
        List<Item> itemList = JsonConvert.DeserializeObject<List<Item>>( jsonText );
    
        foreach( Item item in itemList )
        {
            Debug.Log( item.Name );
        }
