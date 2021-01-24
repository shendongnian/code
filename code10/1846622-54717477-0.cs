        static void PopulateArray(float[] arr1)
        {
            bool vakid;
            for (int i = 0; i < arr1.Length; i++)
            {
                do
                {
                    Console.Write($"Insira nota {i + 1}  ==>");
                    vakid = float.TryParse(Console.ReadLine(), out arr1[i]);
                    if (vakid)
                    {
                        if ((arr1[i] > 20.0) || (arr1[i] < 0.0))
                        {
                            vakid = false;
                            Console.Write("\n\n\t\tAs notas só vão de 0 a 20\n\nPrima uma tecla para continuar");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.Write("\n\n\t\tInvalid Entry\n\nPrima uma tecla para continuar");
                        Console.ReadKey();
                    }                 
                    Console.Clear();
                } while (!vakid);
            }
        }
