    private async Task CallToRun(object sender, EventArgs e)
    {
       while (true) // woah this stil smells
       {
          MyMethod();
          await Task.Delay(2000); // not pausing the message pump, yay
       }
    }
