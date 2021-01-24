csharp
public enum Face
{
    A, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, J, Q, K
}
public Dictionary<Face, string> cardValues = new Dictionary<Face, string> {
    [Face.A] = "A",
    [Face.Two] = "2",
    [Face.Three] = "3",
    ...
}
public string card = cardValues[Face.Two]; // "2"
Personally I'd just store the card value as an integer and use an array instead of the dictionary and enum.
