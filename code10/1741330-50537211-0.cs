    if (iLvl < 1 || iLvl > 100)
    {
        MessageBox.Show("Item Level incorrect! ");
    }
    else if (iLvl <= 4)   // teir 8
    {
        preRoll = obj.Next(5, 9);
    }
    else if (iLvl <= 10)  // teir 7
    {
        preRoll = obj.Next(10, 19);
    }
    else if (iLvl <= 17)  // teir 6
    {
        preRoll = obj.Next(20, 29);
    }
    else if (iLvl <= 23)  // teir 5
    {
        preRoll = obj.Next(30, 39);
    }
    else if (iLvl <= 29)  // teir 4
    {
        preRoll = obj.Next(40, 49);
    }
    else if (iLvl <= 35)  // teir 3
    {
        preRoll = obj.Next(50, 59);
    }
    else if (iLvl <= 43)  // teir 2
    {
        preRoll = obj.Next(60, 69);
    }
    else  // teir 1
    {
        preRoll = obj.Next(70, 79);
    }
