    double wiek;
    double gotowka;
    bool isParsed = double.TryParse(textBox1.Text, out wiek);
    if (!isParsed)
    {
       //TODO: some error handling, telling the user it is not a number
    }
    isParsed = double.TryParse(textBox2.Text, out gotowka);
    if (!isParsed)
    {
       //TODO: some error handling, telling the user it is not a number
    }
