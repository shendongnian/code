    public class my_program
        {
    
            Iconsole _consol;
            public my_program(Iconsole consol)
            {
                if (consol != null)
                    _consol = consol;
            }
            public void greet()
            {
                _consol.WriteToConsole("Hello world");
            }
        }
