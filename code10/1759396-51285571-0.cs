    var input = Encoding.Default.GetBytes("ÇËÅÊÔÑÏÖÏÑÇÓÇ ÁÉÌÏÓÖÁÉÑÉÍÇÓ");
    
    for (var i = 0; i < input.Length; i++)
    {
        if (input[i] == 32) continue;
    
        input[i++] += 11;
        input[i] += 16;
    }
    
    var output = Encoding.UTF8.GetString(input);
