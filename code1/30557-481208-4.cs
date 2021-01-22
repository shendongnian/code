    public Dictionary<CharacteristicType, List<string>> Characteristics;
    ..
    Characteristics.Add(CharacteristicType.Interest, new List<string>());
    Characteristics[CharacteristicType.Interest].Add("Post questions on StackOverflow");
    Characteristics[CharacteristicType.Interest].Add("Answer questions on StackOverflow");
