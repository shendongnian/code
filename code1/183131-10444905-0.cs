    public patial class Form1 : From
    {
        timer1.Start();
        int i = 0;
        int howeverLongYouWantTheLoopToLast = 10;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < howeverLongYouWantTheLoopToLast)
            {
                writeQueryMethodThatIAssumeYouHave(APathMaybe, i); // <-- Just an example, write whatever you want to loop to do here.
                i++;
            }
            else
            {
                timer1.Stop();
                //Maybe add a little message here telling the user the write is done.
            }
        }
    }
