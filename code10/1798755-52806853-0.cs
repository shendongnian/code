    namespace test
    {
        class Program
        {
            static void Main(string[] args)
            {
                // declarar variables
                string dato = "";
    
                int cantPesos = 0;
                int tasaCambio = 0;
                int cantDolares = 0;
                //pedir cantidad de pesos
                Console.WriteLine("Dame la cantidad de pesos");
                dato = Console.ReadLine();
                cantPesos = Convert.ToInt32(dato);
                // pedir cuantos pesos en 1 dolar
    
                Console.WriteLine("cuantos pesos hay en un dolar");
                dato = Console.ReadLine();
                tasaCambio = Convert.ToInt32(dato);
    
                // hacer la conversion
                cantDolares = cantPesos / tasaCambio;
    
                // mostrar resultados
            Console.WriteLine("{0} pesos son {1} dolares", cantPesos, cantDolares);
            }
        }
    }
