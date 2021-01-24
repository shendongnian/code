    //using System;
    //using System.Linq;
    if (!Enum.GetValues(typeof(TestEnum)).Cast<byte>().Contains(testValue))
    {
        throw new InvalidCastException();
    }
