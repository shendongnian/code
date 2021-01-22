    [STAThread]
    private static void Main(string[] args)
    {
        //there's some other code here that initializes the program
        //Starts the first form (login form)
        Application.Run(new form1());
        //Get the login info here somehow. Maybe save in public members of form1 or
        // in a global utilities or global user class of some kind
        //Run the main program
        Application.Run(new mainProgramForm());
    }
