            Console.Write("Enter a number to check if palindrome: ");
            bool palindrome = true;
            int x = int.Parse(Console.ReadLine());
            /* c is x length minus 1 because when counting the strings 
            length it starts from 1 when it should start from 0*/
            int c = x.ToString().Length - 1;
            string b = x.ToString();
            for (int i = 0; i < c; i++)
                if (b[i] != b[c - i])
                    palindrome = false;
            if (palindrome == true)
                Console.Write("Yes");
            else Console.Write("No");
            Console.ReadKey();
