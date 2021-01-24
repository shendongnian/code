    using System;
    using System.Windows.Forms;
    // Allows you to access the static objects of Console
    //     without having to repeatedly type Console.Something.
    using static System.Console;
    static bool configured = false;
    static bool showForm = false;
    static void Main(string[] args) {
        showForm = args.Length < 1;
        if (showForm) {
            WriteLine("The application needs to be configured.");
            using (ConfigForm config = new ConfigForm()) {
                if (config.ShowDialog() == DialogResult.OK) {
                    showForm = false;
                    configured = true;
                    // Set your configured arguments here.
                }
            }
        }
        // Prevents the console from closing.
        while (showForm)
            ReadKey();
        // Do your processing in this condition.
        if (!showForm && configured)
            WriteLine("Thanks for playing. Press any key to exit.");
        else // Retry or exit in this one.
            WriteLine("An error occurred. Press any key to exit.");
        ReadKey();
    }
