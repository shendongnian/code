            int[] test = { 1, 2, 3, 4 };
            modifContenuSansRef(test);
            Console.WriteLine(test[0]); // OK --> 99 le contenu du tableau est modifié
            modifTailleSansRef(test);
            Console.WriteLine(test.Length); // KO --> 4 La taille n'est pas modifiée
        }
        static void modifContenuSansRef(int[] t)
        {
            t[0] = 99;
        }
        static void modifTailleSansRef(int[] t)
        {
            Array.Resize(ref t, 8);
        }
