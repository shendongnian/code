        Dim c As Char() = New Char() { Chr(149) }
        'Dim c As Char() = New Char() { ChrW(149) }
        Dim b As Byte() = System.Text.Encoding.Default.GetBytes(c)
        Console.WriteLine("{0}", Convert.ToInt32(c(0)))
        Console.WriteLine("{0}", CInt(b(0)))
