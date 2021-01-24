    static void PopulateArray(float[] arr1)
    {
        for (int i = 1; i <= arr1.Length; i++)
        {
			float nota;
			
			Console.Write($"Insira nota {i}  ==> \n");
			
			while(! float.TryParse(Console.ReadLine(), out nota) || nota > 20.0f || nota < 0 )
			{
               // Bad input message
				Console.Write("\n\n\t\tAs notas só vão de 0 a 20\n\nPrima uma tecla para continuar");
			}
           
			arr1[i] = nota;
        }
    }
