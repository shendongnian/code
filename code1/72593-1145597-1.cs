    var infinity = 100d / 0;
    var negInfinity = -100d / 0;
    var notANumber = infinity + negInfinity;
    Console.WriteLine("Negative Infinity plus Infinity is NaN: {0}", double.IsNaN(notANumber));
    var notANumber2 = 0d / 0d;
    Console.WriteLine("Zero divided by Zero is NaN: {0}", double.IsNaN(notANumber2));
    Console.WriteLine("These two are not equal: {0}", notANumber == notANumber2);
