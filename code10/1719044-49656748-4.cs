        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var superscripts = "⁰ ¹ ² ³ ⁴ ⁵ ⁶ ⁷ ⁸ ⁹ ¹⁰ ¹¹ ¹² ¹³ ¹⁴ ¹⁵ ¹⁶ 17 18 19 XX XXI XXII XXIII XXIV";
            foreach(var superscript in superscripts.Split(' '))
            {
                Console.WriteLine($"{superscript} ({IsSuperscript(superscript)}) -> {NormalizeSuperscript(superscript)}");
            }
        }
