    public static void OpenFile(){
        string path;
        while(true){
            Console.Write("Enter a path name: ");
            path = Console.ReadLine();
            if(File.Exists(path))
                break;
            Console.WriteLine("File not found");
        }
        string line;
        using(StreamReader stream = File.OpenText(path))
            while((line = stream.ReadLine()) != null)
                Console.WriteLine(line);
    }
