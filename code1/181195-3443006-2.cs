    private static void Main(string[] args)
    {
        //there's some other code here that initializes the program
        //Instead of running a new form here, first create it and then run it
        Form1 form1 = new Form1();    //Creates the form
        Application.Run(form1);       //Runs the form. Program.cs will continue after the form closes
        //Get the login info
        string username = form1.Username;
        string password = form1.Password;
        //Get rid of form1 if you choose
        form1.Dispose();
        //Validate the user info
        //Run the main program
        Application.Run(new mainProgramForm());
    }
