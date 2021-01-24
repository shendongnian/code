    static void MenuAnimal(string[,] animal)
    {
        while ( true )
        {
            int optAnimal;
    
            do
            {
                Console.Clear();
                Console.WriteLine("\nInsert one of the following options:\n");
    
                Console.WriteLine("[ 1 ] Insert animal");
                Console.WriteLine("[ 2 ] See animal");
                Console.WriteLine("[ 3 ] Alter animal");
                Console.WriteLine("[ 4 ] Erase animal");
                Console.WriteLine("[ 5 ] List animals");
                Console.WriteLine("[ 0 ] Return to main menu\n");
    
            } while (!int.TryParse(Console.ReadLine(), out optAnimal) || optAnimal < 0 || optAnimal > 5);
    
            Console.Clear();
            bool goBack = false;
            switch (optAnimal)
            {
                case 1:
                    insertData(animal);
                    break;
                case 2:
                    visualizeByid(animal);
                    break;
                case 3:
                    updateById(animal);
                    break;
                case 4:
                    deleteByid(animal);
                    break;
                case 5:
                    listData(animal);
                    break;    
            }
            if ( goBack ) return;
        }
    }
