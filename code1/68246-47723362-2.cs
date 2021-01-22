    public interface IGobbler
    {
        bool Gobble(ref int amount);
    }
    delegate void GobbleCallback(ref int amount);     // needed for Callback
    delegate bool GobbleReturns(ref int amount);      // needed for Returns
    var mock = new Mock<IGobbler>();
    mock.Setup(m => m.Gobble(ref It.Ref<int>.IsAny))  // match any value passed by-ref
        .Callback(new GobbleCallback((ref int amount) =>
         {
             if (amount > 0)
             {
                 Console.WriteLine("Gobbling...");
                 amount -= 1;
             }
         }))
        .Returns(new GobbleReturns((ref int amount) => amount > 0));
    int a = 5;
    bool gobbleSomeMore = true;
    while (gobbleSomeMore)
    {
        gobbleSomeMore = mock.Object.Gobble(ref a);
    }
