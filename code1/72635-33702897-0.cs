        static void Main(string[] args)
        {
            string c1;
            string c2;
            string c3;
            string c4;
            string c5;
            string c6;
            string c7;
            int sortie;
            bool parfais = true;
            Console.WriteLine("entrer votre code postal");
            string cp = Console.ReadLine();
            if (cp.Length == 7)
            {
                c1 = cp.Substring(0, 1);
                c2 = cp.Substring(1, 1);
                c3 = cp.Substring(2, 1);
                c4 = cp.Substring(3, 1);
                c5 = cp.Substring(4, 1);
                c6 = cp.Substring(5, 1);
                c7 = cp.Substring(6, 1);
                if (int.TryParse(c1, out sortie))
                {
                    parfais = false;
                    Console.WriteLine("le 1er caratere doit etre une lettre");
                }
                if (int.TryParse(c2, out sortie) == false)
                {
                    parfais = false;
                    Console.WriteLine("le 2e caratere doit etre un nombre");
                }
                if (int.TryParse(c3, out sortie))
                {
                    parfais = false;
                    Console.WriteLine("le 3e caratere doit etre une lettre");
                }
                if (c4.Contains(" ") == false)
                {
                    parfais = false;
                    Console.WriteLine("vous devez utiliser un espace");
                }
                if (int.TryParse(c5, out sortie) == false)
                {
                    parfais = false;
                    Console.WriteLine("le 5e caratere doit etre un nombre");
                }
                if (int.TryParse(c6, out sortie))
                {
                    parfais = false;
                    Console.WriteLine("le 6e caratere doit etre une lettre");
                }
                if (int.TryParse(c7, out sortie) == false)
                {
                     parfais = false;
                    Console.WriteLine("le 7e caratere doit etre un nombre");
                }
                else if(parfais == true)
                {
                    Console.WriteLine("code postal accepter");
                    Console.ReadLine();
                }
           }
                else
                {
                    Console.WriteLine("le code postal doit contenir 7 caratere incluant l'espace");
            
                }
            Console.ReadLine();
