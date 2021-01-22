    void ConsumeLoop() {
        foreach (Consumable item in ProduceList())        // might have to wait here
            item.Consume();
    }
    
    IEnumerable<Consumable> ProduceList() {
        while (KeepProducing())
            yield return ProduceExpensiveConsumable();    // expensive
    }
