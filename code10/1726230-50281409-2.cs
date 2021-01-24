    @functions {
        enum templates { Maui, Hawaii, Niihau, Kauai, Kahoolawe, Linai, Molokai, Nihoa };
        templates selectValue = templates.Hawaii;
    
        void DoStuff(UIChangeEventArgs e)
        {
            string area = e.Value.ToString();
            Console.WriteLine("Yay " + area);
            Enum.TryParse(area, out selectValue);
            Console.WriteLine("It is definitely: " + selectValue);
        }
    
    }
