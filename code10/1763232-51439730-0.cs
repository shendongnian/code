            DirectoryInfo parentDir = new DirectoryInfo("C:/Deployment/Test_Folder");
            int i = 1;
            foreach (FileInfo f in parentDir.GetFiles())
            {
                Console.WriteLine($"{i}. {f.Name}");
                i++;
            }
            Console.WriteLine($"Please provide the number of the file your want to select (1-{i}):");
            int id = -1;
            if(Int32.TryParse(Console.ReadLine(),out id))
            {
                FileInfo f = parentDir.GetFiles()[id - 1];
                //Do something
            }
