    // just a sample array
    int[] array = new int[11] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
    object[,] pasteMe = new object[array.Length, 1];
    for (int i = 0; i < array.Length; i++)
        pasteMe[i, 0] = array[i];
    worksheet.Range["A1", "A" + array.Length].Value2 = pasteMe;
