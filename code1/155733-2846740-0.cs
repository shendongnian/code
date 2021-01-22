    int iCount = 0;
    Random random = new Random();
    while (iCount < pictures.Length)
    {
        int attempt = random.Next(0, pictures.Length);
        //Ensures you will only use an available picture
        if (usedPictures[attempt] == false)
        {            
            picBox[attempt].Image= pictures[iCount];
            doorUsed[attempt] = true;
            iCount++;
        }
    }
