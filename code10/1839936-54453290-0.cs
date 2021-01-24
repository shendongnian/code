    int width = 0, height = 0;
    height = 3;
    string myText = "Hello World";
    width = myText.Length + 2;
    for (int i = 1; i <= height; i++)
    {
        for (int j = 1; j <= width; j++)
        {
            if ((i == 1 || i == height) || (j == 1 || j == width))
                Console.Write("*"); //prints at border place
            else
                Console.Write(myText[j - 2]); //prints inside other than border
        }
        Console.WriteLine();
    }
