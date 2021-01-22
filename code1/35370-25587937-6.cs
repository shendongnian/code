    // Manually work with IEnumerator.
    IEnumerator i = carLot.GetEnumerator();
    i.MoveNext();
    Car myCar = (Car)i.Current;
    Console.WriteLine("{0} is going {1} MPH", myCar.PetName, myCar.CurrentSpeed);
