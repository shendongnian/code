    List<SampleSlot> slotsList = new List<SampleSlot>();
    for (int i = 0; i < testSamples.GetLength(0); ++i) {
        for (int j = 0; j < testSamples.GetLength(1); ++j) {
            slotsList.Add(new SampleSlot(i, j, testSamples[i, j]));
        }
    }
    slotsList.Sort();
    // assuming you want your output in descending order
    for (int i = slotsList.Count - 1; i >= 0; --i) {
        SampleSlot slot = slotsList[i];
        Console.WriteLine("testSamples[{0},{1}] = {2}", slot.X, slot.Y, slot.Value);
    }
